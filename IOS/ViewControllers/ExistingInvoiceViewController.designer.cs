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
        UIKit.UILabel _dueDateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _footerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView _invoiceTotalTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _logoImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView _mainScrollView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView _notes { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _payNowButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView _termsAndConditions { get; set; }

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

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint TopBoarderTopConstraint { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView TopBorderView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint TotalTableHeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint TotalTableLeft { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint TotalTableTop { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint TotalTableWidth { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_companyInfoTextView != null) {
                _companyInfoTextView.Dispose ();
                _companyInfoTextView = null;
            }

            if (_dueDateLabel != null) {
                _dueDateLabel.Dispose ();
                _dueDateLabel = null;
            }

            if (_footerView != null) {
                _footerView.Dispose ();
                _footerView = null;
            }

            if (_invoiceTotalTableView != null) {
                _invoiceTotalTableView.Dispose ();
                _invoiceTotalTableView = null;
            }

            if (_logoImageView != null) {
                _logoImageView.Dispose ();
                _logoImageView = null;
            }

            if (_mainScrollView != null) {
                _mainScrollView.Dispose ();
                _mainScrollView = null;
            }

            if (_notes != null) {
                _notes.Dispose ();
                _notes = null;
            }

            if (_payNowButton != null) {
                _payNowButton.Dispose ();
                _payNowButton = null;
            }

            if (_termsAndConditions != null) {
                _termsAndConditions.Dispose ();
                _termsAndConditions = null;
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

            if (TopBoarderTopConstraint != null) {
                TopBoarderTopConstraint.Dispose ();
                TopBoarderTopConstraint = null;
            }

            if (TopBorderView != null) {
                TopBorderView.Dispose ();
                TopBorderView = null;
            }

            if (TotalTableHeight != null) {
                TotalTableHeight.Dispose ();
                TotalTableHeight = null;
            }

            if (TotalTableLeft != null) {
                TotalTableLeft.Dispose ();
                TotalTableLeft = null;
            }

            if (TotalTableTop != null) {
                TotalTableTop.Dispose ();
                TotalTableTop = null;
            }

            if (TotalTableWidth != null) {
                TotalTableWidth.Dispose ();
                TotalTableWidth = null;
            }
        }
    }
}