using Foundation;
using System;
using UIKit;
using ViewModels;

namespace MobileIOS
{
    public partial class DashboardTabBarController : UITabBarController
    {

        public DashboardTabBarController (IntPtr handle) : base (handle)
        {
        }


		public async override void ViewDidLoad ()
		{
			try
			{
				var storyBoard = UIStoryboard.FromName ("ExistingInvoice", null);

				var outstandingNavigationController = storyBoard.InstantiateViewController ("ExistingInvoiceNavigationController") 
				                                     as ExistingInvoiceNavigationController;

				var outstandingViewController = outstandingNavigationController.TopViewController as ExistingInvoiceMenuViewController;

				var outstandingViewModel = AppDelegate.DependencyService.Resolve<ExistingInvoiceMenuViewModel> ();

				((ExistingInvoiceMenuViewModel)outstandingViewModel).MenuType = InvoiceMenuType.Outstanding;
				outstandingViewController.ViewModel = outstandingViewModel as ExistingInvoiceMenuViewModel;
				outstandingViewController.Title = "Outstanding";

				var recentNavigationController = storyBoard.InstantiateViewController ("ExistingInvoiceNavigationController") 
				                                                as ExistingInvoiceNavigationController;

				var recentViewController = recentNavigationController.TopViewController as ExistingInvoiceMenuViewController;

				var recentViewModel = AppDelegate.DependencyService.Resolve<ExistingInvoiceMenuViewModel> ();

				((ExistingInvoiceMenuViewModel)recentViewModel).MenuType = InvoiceMenuType.RecentlyViewed;
				recentViewController.ViewModel = recentViewModel as ExistingInvoiceMenuViewModel;
				recentViewController.Title = "Recently Viewed";

				this.ViewControllers = new UIViewController [] { outstandingViewController, recentViewController };
			}
			catch (Exception e)
			{
			}
		}
    }
}