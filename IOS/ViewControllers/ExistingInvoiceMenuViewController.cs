using Foundation;
using System;
using UIKit;
using ViewModels;

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
				await _viewModel.Start ();
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
}