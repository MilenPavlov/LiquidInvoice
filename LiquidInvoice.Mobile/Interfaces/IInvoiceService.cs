using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary;

namespace Interfaces
{
	public interface IInvoiceService
	{
		Task<IEnumerable<InvoiceDto>> GetAllInvoices ();
	}
}

