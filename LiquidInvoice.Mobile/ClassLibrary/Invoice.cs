using System;
using SQLite;

namespace ClassLibrary
{
	public class Invoice : Resource
	{
		public int InvoiceTypeId { get; set; }

		public int CompanyId { get; set; }

		public int CustomerId { get; set; }

		public double TaxPercentage { get; set; }

		public decimal AmountDue { get; set; }

		public DateTime DueDate { get; set; }

        public DateTime? ViewedUtc { get; set; }

		public string PaymentUrl { get; set; }

		public string InvoiceNumber { get; set; }
	}
}

