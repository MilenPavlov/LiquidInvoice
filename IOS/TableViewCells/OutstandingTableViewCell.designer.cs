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
    [Register ("OutstandingTableViewCell")]
    partial class OutstandingTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _amountDue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _companyLogoImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _companyName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _date { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_amountDue != null) {
                _amountDue.Dispose ();
                _amountDue = null;
            }

            if (_companyLogoImage != null) {
                _companyLogoImage.Dispose ();
                _companyLogoImage = null;
            }

            if (_companyName != null) {
                _companyName.Dispose ();
                _companyName = null;
            }

            if (_date != null) {
                _date.Dispose ();
                _date = null;
            }
        }
    }
}