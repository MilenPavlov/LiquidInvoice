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

		public InvoiceService (IInvoiceTypeRepository invoiceTypeRepository, ICustomerRepository customerRepository, ICompanyRepository companyRepository, IInvoiceRepository invoiceRepository)
		{
			_invoiceTypeRepository = invoiceTypeRepository;
			_customerRepository = customerRepository;
			_companyRepository = companyRepository;
			_invoiceRepository = invoiceRepository;
		}

		public async Task<IEnumerable<InvoiceDto>> GetAllInvoices ()
		{
			try
			{
				var customerResult = await _customerRepository.ReadAllEntities ();
				var companyResult = await _companyRepository.ReadAllEntities ();
				var invoiceResult = await _invoiceRepository.ReadAllEntities ();
				var invoiceTypes = await _invoiceTypeRepository.ReadAllEntities ();

				var invoices = from invoice in invoiceResult.ResultData
							   join customer in customerResult.ResultData on invoice.CustomerId equals customer.Id
							   join company in companyResult.ResultData on invoice.CompanyId equals company.Id
							   join invoiceType in invoiceTypes.ResultData on invoice.InvoiceTypeId equals invoiceType.Id
							   select new InvoiceDto ()
							   {
								   AmountDue = invoice.AmountDue,
								   Company = company,
								   Customer = customer,
								   CompanyId = company.Id,
								   CustomerId = customer.Id,
								   DueDate = invoice.DueDate,
								   InvoiceType = invoiceType
							   };

				var tmp = invoices.ToList ();

				return invoices;
			}
			catch (Exception e)
			{
				return null;
			}
		}
	}
}

