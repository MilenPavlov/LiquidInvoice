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
    [Register ("InvoiceTableViewCell")]
    partial class InvoiceTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _accountNumberLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _amountDueLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _companyLogoImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _dueDateLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_accountNumberLabel != null) {
                _accountNumberLabel.Dispose ();
                _accountNumberLabel = null;
            }

            if (_amountDueLabel != null) {
                _amountDueLabel.Dispose ();
                _amountDueLabel = null;
            }

            if (_companyLogoImageView != null) {
                _companyLogoImageView.Dispose ();
                _companyLogoImageView = null;
            }

            if (_dueDateLabel != null) {
                _dueDateLabel.Dispose ();
                _dueDateLabel = null;
            }
        }
    }
}