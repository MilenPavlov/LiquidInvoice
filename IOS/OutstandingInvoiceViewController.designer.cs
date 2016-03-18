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
    [Register ("OutstandingInvoiceViewController")]
    partial class OutstandingInvoiceViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView OutstandingTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (OutstandingTableView != null) {
                OutstandingTableView.Dispose ();
                OutstandingTableView = null;
            }
        }
    }
}