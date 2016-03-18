using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ClassLibrary;
using Interfaces;

namespace ViewModels
{
	public class NavigationMenuViewModel : IApplicationViewModel
	{
		IDependencyService _dependencyService;
		ICustomerService _customerService;

		IEnumerable<Customer> _customers;

		public NavigationMenuViewModel (IDependencyService dependencyService, ICustomerService customerService)
		{
			_customerService = customerService;
			_dependencyService = dependencyService;
		}

		public event ViewModelNavigationRequestHandler ViewModelNavigationRequested;

		public async Task Start ()
		{
			_customers = await _customerService.GetAllCustomers ().ConfigureAwait(false);
		}

		public void NavigateToDashboard ()
		{
			if (ViewModelNavigationRequested != null)
			{
				IApplicationViewModel viewModel = _dependencyService.Resolve<DashboardViewModel> ();

				ViewModelNavigationRequested (viewModel);
			}
		}
	}
}

