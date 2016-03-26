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
    [Register ("InvoiceItemTableViewCell")]
    partial class InvoiceItemTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _itemNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _quantityLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _totalPriceLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_itemNameLabel != null) {
                _itemNameLabel.Dispose ();
                _itemNameLabel = null;
            }

            if (_quantityLabel != null) {
                _quantityLabel.Dispose ();
                _quantityLabel = null;
            }

            if (_totalPriceLabel != null) {
                _totalPriceLabel.Dispose ();
                _totalPriceLabel = null;
            }
        }
    }
}