using System;
using ClassLibrary;
using DataAccess;
using Interfaces;

namespace DataAccess
{
	public class InvoiceItemRepository : BaseRepository<InvoiceItem>, IInvoiceItemRepository
	{
		public InvoiceItemRepository (ISqliteConnectionService context) : base(context)
		{
		}
	}
}

