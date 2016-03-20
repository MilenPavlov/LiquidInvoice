// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MobileIOS
{
    [Register ("NavigationViewController")]
    partial class NavigationViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView LogoImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView NavigationTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LogoImageView != null) {
                LogoImageView.Dispose ();
                LogoImageView = null;
            }

            if (NavigationTableView != null) {
                NavigationTableView.Dispose ();
                NavigationTableView = null;
            }
        }
    }
}