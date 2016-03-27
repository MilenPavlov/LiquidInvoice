using System;
using System.Threading.Tasks;
using ClassLibrary;
using Interfaces;
using Prism.Events;

namespace ViewModels
{
	public class ExistingInvoiceViewModel : IApplicationViewModel
	{
		InvoiceDto _invoice;
		IInvoiceService _invoiceService;

		public ExistingInvoiceViewModel (IInvoiceService invoiceService)
		{
			_invoiceService = invoiceService;
		}

		public event ViewModelNavigationRequestHandler ViewModelNavigationRequested;

		public async Task Start ()
		{
			await _invoiceService.UpdateViewedUtc (_invoice.Id);
		}

		public InvoiceDto Invoice
		{
			get
			{
				return _invoice;
			}
			set
			{
				_invoice = value;
			}
		}
	}
}

