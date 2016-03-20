using System;
namespace ClassLibrary
{
	public class InvoiceDto
	{
		public int CompanyId { get; set; }

		public int CustomerId { get; set; }

		public decimal AmountDue { get; set; }

		public DateTime DueDate { get; set; }

		public Company Company { get; set; }

		public Customer Customer { get; set; }
	}
}

