using System;
using System.Threading.Tasks;
using Interfaces;

namespace ViewModels
{
	public class OutstandingInvoiceViewModel : IApplicationViewModel
	{
		public OutstandingInvoiceViewModel ()
		{
		}

		public event ViewModelNavigationRequestHandler ViewModelNavigationRequested;

		public Task Start ()
		{
			return Task.FromResult (0);
		}
	}
}

