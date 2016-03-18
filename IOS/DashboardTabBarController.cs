using Foundation;
using System;
using UIKit;
using ViewModels;

namespace MobileIOS
{
    public partial class DashboardTabBarController : UITabBarController
    {
		private DashboardViewModel _viewModel;

        public DashboardTabBarController (IntPtr handle) : base (handle)
        {
        }


		public async override void ViewDidLoad ()
		{
			try
			{
				if (_viewModel != null)
				{
					
				}
			}
			catch (Exception e)
			{
			}
		}


		public DashboardViewModel ViewModel
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