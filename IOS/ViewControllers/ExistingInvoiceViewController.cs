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
				
				_logoImageView.Layer.BorderWidth = 1;
				_logoImageView.Layer.BorderColor = UIColor.Black.CGColor;
				_mainScrollView.Layer.BorderWidth = 1;
				_mainScrollView.Layer.BorderColor = UIColor.Black.CGColor;


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
}