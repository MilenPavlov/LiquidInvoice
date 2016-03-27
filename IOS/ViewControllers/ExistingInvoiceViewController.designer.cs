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
    [Register ("ExistingInvoiceViewController")]
    partial class ExistingInvoiceViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView _companyInfoTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _logoImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView _mainScrollView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView InvoiceItemsTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint LogoHeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint LogoLeft { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint LogoRight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint LogoTop { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint TableViewHeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint TableViewWidth { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_companyInfoTextView != null) {
                _companyInfoTextView.Dispose ();
                _companyInfoTextView = null;
            }

            if (_logoImageView != null) {
                _logoImageView.Dispose ();
                _logoImageView = null;
            }

            if (_mainScrollView != null) {
                _mainScrollView.Dispose ();
                _mainScrollView = null;
            }

            if (InvoiceItemsTableView != null) {
                InvoiceItemsTableView.Dispose ();
                InvoiceItemsTableView = null;
            }

            if (LogoHeight != null) {
                LogoHeight.Dispose ();
                LogoHeight = null;
            }

            if (LogoLeft != null) {
                LogoLeft.Dispose ();
                LogoLeft = null;
            }

            if (LogoRight != null) {
                LogoRight.Dispose ();
                LogoRight = null;
            }

            if (LogoTop != null) {
                LogoTop.Dispose ();
                LogoTop = null;
            }

            if (TableViewHeight != null) {
                TableViewHeight.Dispose ();
                TableViewHeight = null;
            }

            if (TableViewWidth != null) {
                TableViewWidth.Dispose ();
                TableViewWidth = null;
            }
        }
    }
}