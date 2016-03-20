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
    [Register ("ExistingInvoiceMenuViewController")]
    partial class ExistingInvoiceMenuViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView _existingInvoiceTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_existingInvoiceTableView != null) {
                _existingInvoiceTableView.Dispose ();
                _existingInvoiceTableView = null;
            }
        }
    }
}