using Foundation;
using System;
using UIKit;
using ViewModels;
using System.Collections.Generic;
using ClassLibrary;
using System.Linq;

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

				await _viewModel.Start ();

				_existingInvoiceTableView.RowHeight = 95;
				_existingInvoiceTableView.Source = new ExistingInvoiceMenuTableViewSource (_viewModel.Invoices);
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

		public ExistingInvoiceMenuTableViewSource (IEnumerable<InvoiceDto> invoices)
		{
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
	}
}