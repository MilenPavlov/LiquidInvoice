using Foundation;
using System;
using UIKit;
using System.Linq;

namespace MobileIOS
{
    public partial class NewInvoicePagedViewController : UIPageViewController
    {
		UIViewController [] _pages;

        public NewInvoicePagedViewController (IntPtr handle) : base (handle)
        {
        }

		public override void LoadView ()
		{
			base.LoadView ();

			var viewOne = Storyboard.InstantiateViewController ("SetupInvoiceViewController");
			var viewTwo = Storyboard.InstantiateViewController ("SetupInvoiceViewController");

			_pages = new UIViewController [] { viewOne, viewTwo };

			this.SetViewControllers (new UIViewController [] { _pages [0] }, UIPageViewControllerNavigationDirection.Forward, true, (args) => { });
			this.DataSource = new NewInvoicePagedViewControllerDataSource (_pages);
		}
    }

	public class NewInvoicePagedViewControllerDataSource : UIPageViewControllerDataSource
	{
		UIViewController [] _pages;
		int _pageIndex;

		public NewInvoicePagedViewControllerDataSource (UIViewController [] pages)
		{
			_pages = pages;
			_pageIndex = 0;
		}

		public override nint GetPresentationCount (UIPageViewController pageViewController)
		{
			return _pages.Count ();
		}

		public override nint GetPresentationIndex (UIPageViewController pageViewController)
		{
			return _pageIndex;
		}

		public override UIViewController GetNextViewController (UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			if (_pageIndex == (_pages.Count () - 1))
			{
				_pageIndex = 0;
			}
			else
			{
				_pageIndex++;
			}

			return _pages [_pageIndex];
		}

		public override UIViewController GetPreviousViewController (UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			if (_pageIndex == 0)
			{
				_pageIndex = _pages.Count() - 1;
			}
			else
			{
				_pageIndex--;
			}

			return _pages [_pageIndex];
		}
	}
}