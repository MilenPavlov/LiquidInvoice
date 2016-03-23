using Foundation;
using System;
using UIKit;
using ViewModels;
using SDWebImage;
using ClassLibrary;

namespace MobileIOS
{
    public partial class ExistingInvoiceViewController : UIViewController
    {
		ExistingInvoiceViewModel _viewModel;

        public ExistingInvoiceViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad ()
		{
			if (_viewModel != null)
			{
				
			}
		}

		public override void LoadView ()
		{
			base.LoadView ();

			if (_viewModel != null)
			{
				SetImageConstraints (_viewModel.Invoice.InvoiceType.LogoPosition);
				_logoImageView.Layer.BorderWidth = 1;
				_logoImageView.Layer.BorderColor = UIColor.Black.CGColor;
				_mainScrollView.Layer.BorderWidth = 1;
				_mainScrollView.Layer.BorderColor = UIColor.Black.CGColor;

				var frame = _mainScrollView.ContentSize;
				frame.Width = this.View.Frame.Width;
				_mainScrollView.ContentSize = frame;
				_logoImageView.SetImage(new NSUrl(_viewModel.Invoice.Company.LogoUrl));

				if (_viewModel.Invoice.InvoiceType.StretchLogo)
				{
					_logoImageView.ContentMode = UIViewContentMode.ScaleToFill;
				}
				else
				{
					_logoImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
				}
			}
		}

		private void SetImageConstraints (LogoPositionType positionType)
		{
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
				ImageViewRight.Constant = this.View.Frame.Width * 0.75f;
				break;
			case LogoPositionType.Right:
				ImageViewHeight.Constant = 150;
				ImageViewTop.Constant = 0;
				ImageViewRight.Constant = 0;
				ImageViewLeft.Constant = this.View.Frame.Width * 0.75f;
				break;
			case LogoPositionType.Middle:
				ImageViewHeight.Constant = 150;
				ImageViewTop.Constant = 0;
				ImageViewLeft.Constant = this.View.Frame.Width / 2 - 75;
				ImageViewRight.Constant = this.View.Frame.Width / 2 - 75;
				break;
			}

//			_logoImageView.UpdateConstraints ();
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
}