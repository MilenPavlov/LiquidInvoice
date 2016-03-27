using Foundation;
using System;
using UIKit;
using ClassLibrary;
using SDWebImage;

namespace MobileIOS
{
	public partial class InvoiceTableViewCell : UITableViewCell
    {
        public InvoiceTableViewCell (IntPtr handle) : base (handle)
        {
        }

		public void UpdateCell (InvoiceDto invoice)
		{
			_companyLogoImageView.SetImage (new NSUrl (invoice.Company.LogoUrl));
				

			_companyNameLabel.Text = invoice.Company.Name;

			string dueDatePrefix = "Due: ";
			var dueDateText = new NSMutableAttributedString (dueDatePrefix + invoice.DueDate.ToShortDateString());
			dueDateText.AddAttribute (UIStringAttributeKey.ForegroundColor, UIColor.DarkGray, new NSRange (0, dueDatePrefix.Length));

			if (invoice.DueDate.Date <= DateTime.Now.Date)
			{
				dueDateText.AddAttribute (UIStringAttributeKey.ForegroundColor, UIColor.Red, new NSRange (dueDatePrefix.Length, invoice.DueDate.ToShortDateString().Length));
			}

			_dueDateLabel.AttributedText = dueDateText;

			string amountDuePrefix = "Amount: ";
			var amountDueText = new NSMutableAttributedString (amountDuePrefix + "$" + string.Format("{0:n2}", invoice.AmountDue));
			amountDueText.AddAttribute (UIStringAttributeKey.ForegroundColor, UIColor.DarkGray, new NSRange (0, amountDuePrefix.Length));
			_amountDueLabel.AttributedText = amountDueText;

			string accountNumberPrefix = "Acct#: ";
			var accountNumberText = new NSMutableAttributedString (accountNumberPrefix + invoice.Company.AccountNumber);
			accountNumberText.AddAttribute (UIStringAttributeKey.ForegroundColor, UIColor.DarkGray, new NSRange (0, accountNumberPrefix.Length));
			_accountNumberLabel.AttributedText = accountNumberText;
		}
    }
}