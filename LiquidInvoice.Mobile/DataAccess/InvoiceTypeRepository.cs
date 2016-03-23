using System;
using ClassLibrary;
using DataAccess;
using Interfaces;

namespace DataAccess
{
	public class InvoiceTypeRepository : BaseRepository<InvoiceType>, IInvoiceTypeRepository
	{
		public InvoiceTypeRepository (ISqliteConnectionService context) : base(context)
		{
		}
	}
}

