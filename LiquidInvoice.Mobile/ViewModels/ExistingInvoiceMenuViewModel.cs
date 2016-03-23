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
		IDependencyService _dependencyService;

		public ExistingInvoiceMenuViewModel (IInvoiceService invoiceService, IDependencyService dependencyService)
		{
			_dependencyService = dependencyService;
			_invoiceService = invoiceService;
		}

		public event ViewModelNavigationRequestHandler ViewModelNavigationRequested;

		public async Task Start ()
		{
			var invoices = await _invoiceService.GetAllInvoices ().ConfigureAwait (false);
			_invoices = invoices.ToList ();
		}

		public void NavigateToInvoice (InvoiceDto invoice)
		{
			if (ViewModelNavigationRequested != null)
			{
				var viewModel = _dependencyService.Resolve<ExistingInvoiceViewModel> ();

				viewModel.Invoice = invoice;

				ViewModelNavigationRequested (viewModel);
			}
		}

		public List<InvoiceDto> Invoices
		{
			get
			{
				return _invoices;
			}
		}
	}
}

