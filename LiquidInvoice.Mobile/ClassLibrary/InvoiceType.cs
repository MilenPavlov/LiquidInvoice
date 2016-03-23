using System;
namespace ClassLibrary
{
	public class InvoiceType : Resource
	{
		public LogoPositionType LogoPosition { get; set; }

		public int FontSize { get; set; }

		public bool ShowPaymentOptions { get; set; }

		public bool StretchLogo { get; set; }
	}
}