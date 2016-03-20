using System;
using ClassLibrary;
using DataAccess;
using Interfaces;

namespace DataAcess
{
	public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
	{
		public InvoiceRepository (ISqliteConnectionService context) : base (context)
		{
		}
	}
}

