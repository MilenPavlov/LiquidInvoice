using System;
using System.Collections.Generic;

namespace ClassLibrary
{
	public class InvoiceDto
	{
		public int CompanyId { get; set; }

		public int CustomerId { get; set; }

		public decimal AmountDue { get; set; }

		public DateTime DueDate { get; set; }

		public string PaymentUrl { get; set; }

		public Company Company { get; set; }

		public Customer Customer { get; set; }

		public InvoiceType InvoiceType { get; set; }

		public IEnumerable<InvoiceItem> InvoiceItems { get; set; }
	}
}

