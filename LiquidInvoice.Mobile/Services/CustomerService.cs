using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary;
using Interfaces;

namespace Services
{
	public class CustomerService : ICustomerService
	{
		ICustomerRepository _customerRepository;

		public CustomerService (ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;	
		}

		public async Task<IEnumerable<Customer>> GetAllCustomers ()
		{
			try
			{
				var customers = await _customerRepository.ReadAllEntities ().ConfigureAwait (false);

				if (customers.ResultCode == RepositoryResultCode.Error)
				{
					throw new InvalidOperationException ("Repository returned error: " + customers.ResultDescription);
				}

				return customers.ResultData;
			}
			catch (Exception e)
			{
				return null;
			}
		}
	}
}

