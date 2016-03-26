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
        UIKit.NSLayoutConstraint ImageViewHeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint ImageViewLeft { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint ImageViewRight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint ImageViewTop { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView InvoiceItemsTableView { get; set; }

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

            if (ImageViewHeight != null) {
                ImageViewHeight.Dispose ();
                ImageViewHeight = null;
            }

            if (ImageViewLeft != null) {
                ImageViewLeft.Dispose ();
                ImageViewLeft = null;
            }

            if (ImageViewRight != null) {
                ImageViewRight.Dispose ();
                ImageViewRight = null;
            }

            if (ImageViewTop != null) {
                ImageViewTop.Dispose ();
                ImageViewTop = null;
            }

            if (InvoiceItemsTableView != null) {
                InvoiceItemsTableView.Dispose ();
                InvoiceItemsTableView = null;
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