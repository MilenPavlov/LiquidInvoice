using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using Interfaces;

namespace MobileIOS
{
	public partial class NavigationViewController : UIViewController
	{
		private NavigationMenuViewModel _viewModel;

		public NavigationViewController (IntPtr handle) : base (handle)
		{

		}

		public async override void ViewDidLoad ()
		{
			NavigationTableView.TableFooterView = new UIView ();

			LogoImageView.UserInteractionEnabled = true;
			LogoImageView.AddGestureRecognizer (new UITapGestureRecognizer (() => { 
				NavigateToDashboard ();

				foreach (var index in NavigationTableView.IndexPathsForVisibleRows)
				{
					NavigationTableView.DeselectRow (index, true);
				}
			}));


			if (_viewModel != null)
			{
				_viewModel.ViewModelNavigationRequested += OnNavigationRequested;

				await _viewModel.Start ();

				var actions = new List<KeyValuePair<string, Action>> ();
				actions.Add (new KeyValuePair<string, Action> ("New Invoice", NavigateToNewInvoice));
				actions.Add (new KeyValuePair<string, Action> ("Existing Invoices", _viewModel.NavigateToExistingInvoiceMenu));
				actions.Add (new KeyValuePair<string, Action> ("Reports", NavigateToReportMenu));

				NavigationTableView.Source = new NavigationTableViewSource (actions);
				NavigationTableView.ReloadData ();
			}
		}

		private void OnNavigationRequested (IApplicationViewModel viewModel)
		{
			if (viewModel is ExistingInvoiceMenuViewModel)
			{
				var storyBoard = UIStoryboard.FromName ("ExistingInvoice", null);

				var navigationController = storyBoard.InstantiateViewController ("ExistingInvoiceNavigationController") 
				                                     as ExistingInvoiceNavigationController;

				var viewController = navigationController.TopViewController as ExistingInvoiceMenuViewController;

				viewController.ViewModel = viewModel as ExistingInvoiceMenuViewModel;

				this.ShowDetailViewController (navigationController, this);
			}
		}

		private void NavigateToDashboard ()
		{
			var detailNavigationController = Storyboard.InstantiateViewController ("DashboardNavigationController") as DashboardNavigationController;
			this.ShowDetailViewController (detailNavigationController, this);
		}


		private void NavigateToNewInvoice ()
		{
			var viewController = Storyboard.InstantiateViewController ("NewInvoiceNavigationController");
			this.ShowDetailViewController (viewController, this);
		}

		private void NavigateToReportMenu ()
		{
			var storyBoard = UIStoryboard.FromName ("Reports", null);
			var viewController = storyBoard.InstantiateViewController ("ReportsNavigationController");
			this.ShowDetailViewController (viewController, this);
		}

		public NavigationMenuViewModel ViewModel
		{
			get
			{
				return _viewModel;
			}
			set
			{
				_viewModel = value;
			}
		}
	}

	public class NavigationTableViewSource : UITableViewSource
	{
		IEnumerable<KeyValuePair<string, Action>> _actions;

		public NavigationTableViewSource (IEnumerable<KeyValuePair<string, Action>> actions)
		{
			_actions = actions;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = new UITableViewCell (UITableViewCellStyle.Default, null);
			cell.TextLabel.Text = _actions.ElementAt (indexPath.Row).Key;
			return cell;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return _actions.Count ();
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			_actions.ElementAt (indexPath.Row).Value ();
		}
	}
}