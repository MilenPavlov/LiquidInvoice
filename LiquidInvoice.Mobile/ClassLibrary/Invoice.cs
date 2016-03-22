using System;
using SQLite;

namespace ClassLibrary
{
	public class Invoice : Resource
	{
		public int InvoiceTypeId { get; set; }

		public int CompanyId { get; set; }

		public int CustomerId { get; set; }

		public decimal AmountDue { get; set; }

		public DateTime DueDate { get; set; }
	}
}

