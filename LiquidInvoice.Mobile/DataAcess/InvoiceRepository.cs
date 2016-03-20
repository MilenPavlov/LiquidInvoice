using System;
using ClassLibrary;
using DataAccess;
using Interfaces;

namespace DataAccess
{
	public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
	{
		public InvoiceRepository (ISqliteConnectionService context) : base (context)
		{
			context.Instance.ExecuteAsync ("Update Invoice Set DueDate = ", DateTime.Now);
		}
	}
}

