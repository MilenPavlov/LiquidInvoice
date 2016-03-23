using Foundation;
using System;
using UIKit;
using ViewModels;
using System.Collections.Generic;
using ClassLibrary;
using System.Linq;
using Interfaces;

namespace MobileIOS
{
    public partial class ExistingInvoiceMenuViewController : UIViewController
    {
		ExistingInvoiceMenuViewModel _viewModel;

        public ExistingInvoiceMenuViewController (IntPtr handle) : base (handle)
        {
        }

		public async override void ViewDidLoad ()
		{
			if (_viewModel != null)
			{
				_existingInvoiceTableView.TableFooterView = new UIView ();
				_viewModel.ViewModelNavigationRequested += OnViewModelNavigationRequested;

				await _viewModel.Start ();

				_existingInvoiceTableView.RowHeight = 95;
				_existingInvoiceTableView.Source = new ExistingInvoiceMenuTableViewSource (_viewModel.Invoices, _viewModel.NavigateToInvoice);
				_existingInvoiceTableView.ReloadData ();
			}
		}

		private void OnViewModelNavigationRequested(IApplicationViewModel viewModel)
		{
			try
			{
				if (viewModel is ExistingInvoiceViewModel)
				{
					PerformSegue ("InvoiceSegue", new ViewModelNavigationContainer { TargetViewModel = viewModel});
				}
			}
			catch(Exception e)
			{
				
			}
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			try
			{
				base.PrepareForSegue (segue, sender);

				if (segue.Identifier == "InvoiceSegue")
				{
					var target = (ViewModelNavigationContainer)sender;
					var destinationViewModel = target.TargetViewModel;
					var destinationViewController = segue.DestinationViewController as ExistingInvoiceViewController;
					destinationViewController.ViewModel = destinationViewModel as ExistingInvoiceViewModel;
				}
			}
			catch(Exception e)
			{
				
			}
		}

		public ExistingInvoiceMenuViewModel ViewModel
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

	public class ExistingInvoiceMenuTableViewSource : UITableViewSource
	{
		IEnumerable<InvoiceDto> _invoices;
		ExistingInvoiceTableRowClicked _rowSelected;

		public ExistingInvoiceMenuTableViewSource (IEnumerable<InvoiceDto> invoices, ExistingInvoiceTableRowClicked rowSelected)
		{
			_rowSelected = rowSelected;
			_invoices = invoices;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("InvoiceTableViewCell") as InvoiceTableViewCell;
			cell.UpdateCell (_invoices.ElementAt (indexPath.Row));
			return cell;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return _invoices.Count ();
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			if (_rowSelected != null)
			{
				_rowSelected (_invoices.ElementAt (indexPath.Row));
			}
		}
	}

	public delegate void ExistingInvoiceTableRowClicked (InvoiceDto invoice);
}