using Foundation;
using System;
using UIKit;
using ViewModels;
using SDWebImage;
using ClassLibrary;
using System.Collections.Generic;
using System.Linq;

namespace MobileIOS
{
    public partial class ExistingInvoiceViewController : UIViewController
    {
		ExistingInvoiceViewModel _viewModel;

		const int RowHeight = 60;

        public ExistingInvoiceViewController (IntPtr handle) : base (handle)
        {
        }

		public override void WillRotate (UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			TableViewWidth.Constant = toInterfaceOrientation.IsLandscape() ?  
				this.View.Frame.Width - SplitViewController.PrimaryColumnWidth - 30: 
				this.View.Frame.Width - 30;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (_viewModel != null)
			{
				_companyInfoTextView.Text = _viewModel.Invoice.Company.Name + '\n' +
					_viewModel.Invoice.Company.Address + '\n' +
					_viewModel.Invoice.Company.PhoneNumber;

				_companyInfoTextView.SizeToFit ();

				InvoiceItemsTableView.RowHeight = RowHeight;
				InvoiceItemsTableView.UserInteractionEnabled = false;

				InvoiceItemsTableView.Source = new InvoiceItemsTableViewSource (_viewModel.Invoice.InvoiceItems);
			}
		}

		public override void LoadView ()
		{
			base.LoadView ();

			if (_viewModel != null)
			{
				InvoiceItemsTableView.Layer.BorderColor = UIColor.LightGray.CGColor;
				InvoiceItemsTableView.Layer.BorderWidth = 1;
				InvoiceItemsTableView.Layer.CornerRadius = 5;

				TableViewWidth.Constant = InterfaceOrientation.IsLandscape() ?  
					this.View.Frame.Width - SplitViewController.PrimaryColumnWidth - 30: 
					this.View.Frame.Width - 30;


				TableViewHeight.Constant = RowHeight * _viewModel.Invoice.InvoiceItems.Count ();

				_logoImageView.SetImage(new NSUrl(_viewModel.Invoice.Company.LogoUrl));

				if (_viewModel.Invoice.InvoiceType.StretchLogo)
				{
					_logoImageView.ContentMode = UIViewContentMode.ScaleToFill;
				}
				else
				{
					_logoImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
				}

				SetImageConstraints (_viewModel.Invoice.InvoiceType.LogoPosition);
			}
		}

		private void SetImageConstraints (LogoPositionType positionType)
		{
			nfloat primaryColumnOffset = InterfaceOrientation.IsLandscape () ? SplitViewController.PrimaryColumnWidth : 0;

			switch (positionType)
			{
			case LogoPositionType.FullLength:
				ImageViewHeight.Constant = 150;
				ImageViewTop.Constant = 0;
				ImageViewLeft.Constant = 0;
				ImageViewRight.Constant = 0;
				break;
			case LogoPositionType.Left:
				ImageViewHeight.Constant = 150;
				ImageViewTop.Constant = 0;
				ImageViewLeft.Constant = 0;
				ImageViewRight.Constant = this.View.Frame.Width * 0.75f - primaryColumnOffset;
				break;
			case LogoPositionType.Right:
				ImageViewHeight.Constant = 150;
				ImageViewTop.Constant = 0;
				ImageViewRight.Constant = 0;
				ImageViewLeft.Constant = this.View.Frame.Width * 0.75f - primaryColumnOffset;
				break;
			case LogoPositionType.Middle:
				ImageViewHeight.Constant = 150;
				ImageViewTop.Constant = 0;
				ImageViewLeft.Constant = this.View.Frame.Width / 2 - 75 - primaryColumnOffset;
				ImageViewRight.Constant = this.View.Frame.Width / 2 - 75 - primaryColumnOffset;
				break;
			}
		}

		public ExistingInvoiceViewModel ViewModel
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

	public class InvoiceItemsTableViewSource : UITableViewSource
	{
		IEnumerable<InvoiceItem> _items;

		public InvoiceItemsTableViewSource (IEnumerable<InvoiceItem> items)
		{
			_items = items;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("InvoiceItemTableViewCell") as InvoiceItemTableViewCell;
			cell.UpdateCell (_items.ElementAt (indexPath.Row));
			return cell;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return _items.Count ();
		}
	}
}