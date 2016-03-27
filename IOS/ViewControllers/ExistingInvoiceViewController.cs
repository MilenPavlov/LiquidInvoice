using Foundation;
using System;
using UIKit;
using ViewModels;
using SDWebImage;
using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using CoreAnimation;
using CoreGraphics;

namespace MobileIOS
{
    public partial class ExistingInvoiceViewController : UIViewController
    {
		ExistingInvoiceViewModel _viewModel;

		const int RowHeight = 50;

        public ExistingInvoiceViewController (IntPtr handle) : base (handle)
        {
        }

		public override void WillRotate (UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			TableViewWidth.Constant = toInterfaceOrientation.IsLandscape() ?  
				this.View.Frame.Width - SplitViewController.PrimaryColumnWidth - 30: 
				this.View.Frame.Width - 30;
		}

		public async override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (_viewModel != null)
			{
				await _viewModel.Start ();

				_companyInfoTextView.Text = _viewModel.Invoice.Company.Name + '\n' +
					_viewModel.Invoice.Company.Address + ' ' + _viewModel.Invoice.Company.PhoneNumber;
				_companyInfoTextView.Font = AppDelegate.DefaultFontOfSize(15);

				InvoiceItemsTableView.RowHeight = RowHeight;
				InvoiceItemsTableView.UserInteractionEnabled = false;
				InvoiceItemsTableView.TableFooterView = new UIView ();
				InvoiceItemsTableView.Source = new InvoiceItemsTableViewSource (_viewModel.Invoice.InvoiceItems);

				var values = new List<KeyValuePair<string, decimal>> () {
					new KeyValuePair<string, decimal>("Sub Total: ", _viewModel.Invoice.AmountDue),
					new KeyValuePair<string, decimal>("Tax: ", _viewModel.Invoice.AmountDue * Convert.ToDecimal(_viewModel.Invoice.TaxPercentage)),
					new KeyValuePair<string, decimal>("Total: ",_viewModel.Invoice.AmountDue * Convert.ToDecimal(_viewModel.Invoice.TaxPercentage) + _viewModel.Invoice.AmountDue)
				};

				_dueDateLabel.Text = "Due: " + _viewModel.Invoice.DueDate.ToShortDateString ();
				_dueDateLabel.TextAlignment = UITextAlignment.Right;

				_notes.Text = "Notes: \n\t" + "Some notes";
				_notes.BackgroundColor = UIColor.Clear;
				_notes.Font = AppDelegate.DefaultFontOfSize(15);

				_termsAndConditions.Font = AppDelegate.DefaultFontOfSize(15);
				_termsAndConditions.BackgroundColor = UIColor.Clear;
				_termsAndConditions.Text = "Terms and Conditions: \n\t" + 
					"Much of the legal information on this website consists of summaries of complex legal issues. " +
					"Legal and factual details and nuances are inevitably omitted from such summaries. Particular circumstances often radically " +
					"affect the law that applies, and the way that the law applies." +
				  " You should therefore never apply the legal information to your own situation without conducting additional research or engaging " +
					" a lawyer. Nor should you assume that all of the relevant legal material is included on our website. ";

				_invoiceTotalTableView.BackgroundColor = UIColor.Clear;
				_invoiceTotalTableView.RowHeight = RowHeight;
				_invoiceTotalTableView.UserInteractionEnabled = false;
				_invoiceTotalTableView.Source = new InvoiceTotalTableViewSource (values);

				_invoiceTotalTableView.TableFooterView = new UIView (new CGRect (0, 0, TotalTableWidth.Constant, 50));
				this.View.BringSubviewToFront (TopBorderView);
			}
		}

		public override void LoadView ()
		{
			base.LoadView ();

			if (_viewModel != null)
			{
				var buttonTitle = new NSAttributedString("Pay Now", new UIStringAttributes() {
					Font = AppDelegate.DefaultFontOfSize(17)
				});

				_payNowButton.SetAttributedTitle(buttonTitle, UIControlState.Normal);
				_payNowButton.SetAttributedTitle(buttonTitle, UIControlState.Focused);
				_payNowButton.TouchDown += NavigateToPaymentSite;

				InvoiceItemsTableView.Layer.BorderColor = UIColor.LightGray.CGColor;
				InvoiceItemsTableView.Layer.BorderWidth = 1;
				InvoiceItemsTableView.Layer.CornerRadius = 5;

				_invoiceTotalTableView.Layer.BorderWidth = 1;
				_invoiceTotalTableView.Layer.BorderColor = UIColor.LightGray.CGColor;
				_invoiceTotalTableView.Layer.CornerRadius = 5;

				_footerView.Layer.CornerRadius = 5;

				TableViewWidth.Constant = InterfaceOrientation.IsLandscape() ?  
					this.View.Frame.Width - SplitViewController.PrimaryColumnWidth - 30: 
					this.View.Frame.Width - 30;

				TotalTableLeft.Constant = (TableViewWidth.Constant / 2) + 30;
				TotalTableTop.Constant = -8;
				TotalTableWidth.Constant = (TableViewWidth.Constant / 2) - 15;
				TotalTableHeight.Constant = RowHeight * 3;

				_invoiceTotalTableView.TableFooterView = new UIView ();

				if (_viewModel.Invoice.InvoiceItems.Any ())
				{
					TableViewHeight.Constant = RowHeight * _viewModel.Invoice.InvoiceItems.Count ();
				}

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

		private void NavigateToPaymentSite (object sender, EventArgs args)
		{
			if (!string.IsNullOrWhiteSpace (_viewModel.Invoice.PaymentUrl))
			{
				UIApplication.SharedApplication.OpenUrl (new NSUrl (_viewModel.Invoice.PaymentUrl));
			}
		}

		private void SetImageConstraints (LogoPositionType positionType)
		{
			nfloat primaryColumnOffset = InterfaceOrientation.IsLandscape () ? SplitViewController.PrimaryColumnWidth : 0;
			nfloat logoHeight = 150;
			nfloat imageOffset = 10;

			switch (positionType)
			{
			case LogoPositionType.FullLength:
				LogoHeight.Constant = logoHeight;
				LogoTop.Constant = imageOffset;
				LogoLeft.Constant = imageOffset;
				LogoRight.Constant = imageOffset;
				break;
			case LogoPositionType.Left:
				LogoHeight.Constant = logoHeight;
				LogoTop.Constant = imageOffset;
				LogoLeft.Constant = imageOffset;
				LogoRight.Constant = this.View.Frame.Width * 0.75f - primaryColumnOffset;
				break;
			case LogoPositionType.Right:
				LogoHeight.Constant = logoHeight;
				LogoTop.Constant = imageOffset;
				LogoLeft.Constant = this.View.Frame.Width * 0.75f - primaryColumnOffset;
				LogoRight.Constant = imageOffset;
				break;
			case LogoPositionType.Middle:
				LogoHeight.Constant = logoHeight;
				LogoTop.Constant = imageOffset;
				LogoLeft.Constant = this.View.Frame.Width / 2 - 75 - primaryColumnOffset;
				LogoRight.Constant = this.View.Frame.Width / 2 - 75 - primaryColumnOffset;
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

	public class InvoiceTotalTableViewSource : UITableViewSource
	{
		IEnumerable<KeyValuePair<string, decimal>> _values;

		public InvoiceTotalTableViewSource (IEnumerable<KeyValuePair<string, decimal>> values)
		{
			_values = values;
		}
		
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var value = _values.ElementAt (indexPath.Row);
			var cell = tableView.DequeueReusableCell ("InvoiceTotalTableViewCell") as InvoiceTotalTableViewCell;

			cell.UpdateCell (value.Key, value.Value);
			return cell;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return _values.Count ();
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