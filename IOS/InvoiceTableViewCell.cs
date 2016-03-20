using Foundation;
using System;
using UIKit;
using ClassLibrary;

namespace MobileIOS
{
	public partial class InvoiceTableViewCell : UITableViewCell
    {
        public InvoiceTableViewCell (IntPtr handle) : base (handle)
        {
        }

		public void UpdateCell (InvoiceDto invoice)
		{
			//_companyLogoImageView.SetImage (new NSUrl (invoice.Company.LogoUrl));
		}
    }
}