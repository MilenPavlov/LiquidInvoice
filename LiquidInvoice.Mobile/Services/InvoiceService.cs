using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary;
using System.Linq;
using Interfaces;

namespace Services
{
	public class InvoiceService : IInvoiceService
	{
		ICustomerRepository _customerRepository;
		ICompanyRepository _companyRepository;
		IInvoiceRepository _invoiceRepository;
		IInvoiceTypeRepository _invoiceTypeRepository;
		IInvoiceItemRepository _invoiceItemRepository;

		public InvoiceService (
			IInvoiceTypeRepository invoiceTypeRepository,
			ICustomerRepository customerRepository, 
			ICompanyRepository companyRepository, 
			IInvoiceRepository invoiceRepository,
			IInvoiceItemRepository invoiceItemRepository)
		{
			_invoiceItemRepository = invoiceItemRepository;
			_invoiceTypeRepository = invoiceTypeRepository;
			_customerRepository = customerRepository;
			_companyRepository = companyRepository;
			_invoiceRepository = invoiceRepository;
		}

		public async Task<Invoice> UpdateViewedUtc (int invoiceId)
		{
			try
			{
				var invoice = await _invoiceRepository.ReadEntityWhere (i => i.Id == invoiceId);

				invoice.ResultData.ViewedUtc = DateTime.Now.Date.ToUniversalTime ();

				await _invoiceRepository.UpdateAllEntities (new List<Invoice> () { invoice.ResultData });

				return invoice.ResultData;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public async Task<IEnumerable<InvoiceDto>> GetRecentlyViewed ()
		{
			var customerResult = await _customerRepository.ReadAllEntities ();
			var companyResult = await _companyRepository.ReadAllEntities ();
			var invoiceResult = await _invoiceRepository.ReadAllEntities ();
			var invoiceTypes = await _invoiceTypeRepository.ReadAllEntities ();
			var invoiceItems = await _invoiceItemRepository.ReadAllEntities ();


			var invoices = from invoice in invoiceResult.ResultData
                            join customer in customerResult.ResultData on invoice.CustomerId equals customer.Id
                            join company in companyResult.ResultData on invoice.CompanyId equals company.Id
                            join invoiceType in invoiceTypes.ResultData on invoice.InvoiceTypeId equals invoiceType.Id
                            where invoice.ViewedUtc != null 
                            select MapEntityToDto (
                                invoice, 
                                company,
                                customer, 
                                invoiceType, 
                                invoiceItems.ResultData.Where (ii => ii.InvoiceId == invoice.Id)
                               );

			if (invoices.Any ())
			{
				invoices = invoices.OrderBy (i => i.ViewedUtc).Select (i =>
				{

					i.ViewedUtc = i.ViewedUtc.Value.ToLocalTime ();

					return i;
				});
			}

			return invoices;
		}

		public async Task<IEnumerable<InvoiceDto>> GetAllOverdueInvoices ()
		{
			try
			{
				var customerResult = await _customerRepository.ReadAllEntities ();
				var companyResult = await _companyRepository.ReadAllEntities ();
				var invoiceResult = await _invoiceRepository.ReadAllEntities ();
				var invoiceTypes = await _invoiceTypeRepository.ReadAllEntities ();
				var invoiceItems = await _invoiceItemRepository.ReadAllEntities ();


				var invoices = from invoice in invoiceResult.ResultData
							   join customer in customerResult.ResultData on invoice.CustomerId equals customer.Id
							   join company in companyResult.ResultData on invoice.CompanyId equals company.Id
							   join invoiceType in invoiceTypes.ResultData on invoice.InvoiceTypeId equals invoiceType.Id
							   where invoice.DueDate.Date <= DateTime.Now.Date
							   select MapEntityToDto (
                                            invoice, 
                                            company,
                                            customer, 
                                            invoiceType, 
                                            invoiceItems.ResultData.Where (ii => ii.InvoiceId == invoice.Id)
                                           );


				return invoices;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public async Task<IEnumerable<InvoiceDto>> GetAllInvoices ()
		{
			try
			{
				var customerResult = await _customerRepository.ReadAllEntities ();
				var companyResult = await _companyRepository.ReadAllEntities ();
				var invoiceResult = await _invoiceRepository.ReadAllEntities ();
				var invoiceTypes = await _invoiceTypeRepository.ReadAllEntities ();
				var invoiceItems = await _invoiceItemRepository.ReadAllEntities ();

				var invoices = from invoice in invoiceResult.ResultData
							   join customer in customerResult.ResultData on invoice.CustomerId equals customer.Id
							   join company in companyResult.ResultData on invoice.CompanyId equals company.Id
							   join invoiceType in invoiceTypes.ResultData on invoice.InvoiceTypeId equals invoiceType.Id
							   select MapEntityToDto (invoice, company, customer, invoiceType, invoiceItems.ResultData.Where (ii => ii.InvoiceId == invoice.Id));

				return invoices;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		private InvoiceDto MapEntityToDto (Invoice invoice, Company company, Customer customer, InvoiceType invoiceType, IEnumerable<InvoiceItem> invoiceItems)
		{
			return new InvoiceDto { 
				Id = invoice.Id,
				ViewedUtc = invoice.ViewedUtc,
				AmountDue = invoice.AmountDue,
				Company = company,
				Customer = customer,
				InvoiceNumber = invoice.InvoiceNumber,
				TaxPercentage = invoice.TaxPercentage,
				CompanyId = company.Id,
				CustomerId = customer.Id,
				PaymentUrl = invoice.PaymentUrl,
				DueDate = invoice.DueDate,
				InvoiceType = invoiceType,
				InvoiceItems = invoiceItems
			};
		}
	}
}

