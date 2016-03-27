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

		public InvoiceMenuType MenuType { get; set; }

		public ExistingInvoiceMenuViewModel (IInvoiceService invoiceService, IDependencyService dependencyService)
		{
			_dependencyService = dependencyService;
			_invoiceService = invoiceService;
			MenuType = InvoiceMenuType.AllInvoices;
		}

		public event ViewModelNavigationRequestHandler ViewModelNavigationRequested;

		public async Task Start ()
		{
			_invoices = (await GetInvoicesByMenuType (MenuType)).ToList();	
		}

		private async Task<IEnumerable<InvoiceDto>> GetInvoicesByMenuType (InvoiceMenuType menuType)
		{
			switch (MenuType)
			{
			case InvoiceMenuType.AllInvoices:
				return await _invoiceService.GetAllInvoices ().ConfigureAwait (false);
			case InvoiceMenuType.Outstanding:
				return await _invoiceService.GetAllOverdueInvoices ().ConfigureAwait (false);
			case InvoiceMenuType.RecentlyViewed:
				return await _invoiceService.GetRecentlyViewed ().ConfigureAwait (false);
			}

			return new List<InvoiceDto> ();
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

	public enum InvoiceMenuType
	{
		AllInvoices,
		Outstanding,
		RecentlyViewed
	}
}

