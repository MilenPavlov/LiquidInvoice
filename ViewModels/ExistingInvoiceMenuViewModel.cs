using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using Interfaces;

namespace ViewModels
{
	public class ExistingInvoiceMenuViewModel : IApplicationViewModel
	{
		IInvoiceService _invoiceService;
		List<InvoiceDto> _invoices;

		public ExistingInvoiceMenuViewModel (IInvoiceService invoiceService)
		{
			_invoiceService = invoiceService;
		}

		public event ViewModelNavigationRequestHandler ViewModelNavigationRequested;

		public async Task Start ()
		{
			var invoices = await _invoiceService.GetAllInvoices ().ConfigureAwait (false);
			_invoices = invoices.ToList ();
		}
	}
}

