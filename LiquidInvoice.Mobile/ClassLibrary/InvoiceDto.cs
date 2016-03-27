using System;
using System.Collections.Generic;

namespace ClassLibrary
{
	public class InvoiceDto
	{
		public int Id { get; set; }

		public int CompanyId { get; set; }

		public int CustomerId { get; set; }

		public decimal AmountDue { get; set; }

		public double TaxPercentage { get; set; }

		public DateTime DueDate { get; set; }

        public DateTime? ViewedUtc { get; set; }

        public string PaymentUrl { get; set; }

		public string InvoiceNumber { get; set; }

		public Company Company { get; set; }

		public Customer Customer { get; set; }

		public InvoiceType InvoiceType { get; set; }

		public IEnumerable<InvoiceItem> InvoiceItems { get; set; }
	}
}

