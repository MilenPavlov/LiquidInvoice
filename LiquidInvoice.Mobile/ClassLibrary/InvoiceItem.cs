using System;
namespace ClassLibrary
{
	public class InvoiceItem : Resource
	{
		public int InvoiceId { get; set; }

		public string ItemName { get; set; }

		public double? Quantity { get; set; }

		public decimal TotalPrice { get; set; }
	}
}

