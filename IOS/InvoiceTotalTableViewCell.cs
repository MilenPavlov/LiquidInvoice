using Foundation;
using System;
using UIKit;

namespace MobileIOS
{
    public partial class InvoiceTotalTableViewCell : UITableViewCell
    {
        public InvoiceTotalTableViewCell (IntPtr handle) : base (handle)
        {
        }

		public void UpdateCell (string title, decimal amount)
		{
			_nameLabel.Text = title;
			_amountTotal.Text = String.Format ("{0:C2}", amount);
		}
    }
}