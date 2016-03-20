using Foundation;
using System;
using UIKit;
using ViewModels;

namespace MobileIOS
{
    public partial class MainSplitViewController : UISplitViewController
    {
        public MainSplitViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad ()
		{
			var masterViewController = Storyboard.InstantiateViewController ("NavigationViewController") as NavigationViewController;
			var detailNavigationController = Storyboard.InstantiateViewController ("DashboardNavigationController") as DashboardNavigationController;

			masterViewController.ViewModel = AppDelegate.DependencyService.Resolve<NavigationMenuViewModel> ();
			//(detailNavigationController.TopViewController as DashboardViewController).ViewModel = AppDelegate.DependencyService.Resolve<DashboardViewModel> ();

			this.PreferredPrimaryColumnWidthFraction = 0.25f;

			this.ViewControllers = new UIViewController[] { masterViewController, detailNavigationController };
		}
    }
}