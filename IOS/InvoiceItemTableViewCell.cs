using Foundation;
using System;
using UIKit;
using ClassLibrary;

namespace MobileIOS
{
    public partial class InvoiceItemTableViewCell : UITableViewCell
    {
        public InvoiceItemTableViewCell (IntPtr handle) : base (handle)
        {
        }

		public void UpdateCell (InvoiceItem item)
		{
			_itemNameLabel.Text = item.ItemName;

			if (item.Quantity.HasValue)
			{
				_quantityLabel.Hidden = false;

				string quantityPrefix = "Quantity: ";
				var quantityText = new NSMutableAttributedString (quantityPrefix + item.Quantity);
				quantityText.AddAttribute (UIStringAttributeKey.ForegroundColor, UIColor.DarkGray, new NSRange (0, quantityPrefix.Length));

				_quantityLabel.AttributedText = quantityText;
			}
			else
			{
				_quantityLabel.Hidden = true;
			}

			_totalPriceLabel.Text = String.Format ("{0:C2}", item.TotalPrice);
		}
    }
}