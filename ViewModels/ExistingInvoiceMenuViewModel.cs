using System;
using System.Threading.Tasks;
using Interfaces;
using Prism.Mvvm;

namespace ViewModels
{
	public class ExistingInvoiceMenuViewModel : BindableBase, IApplicationViewModel
	{
		
		public ExistingInvoiceMenuViewModel ()
		{
		}

		public event ViewModelNavigationRequestHandler ViewModelNavigationRequested;

		public Task Start ()
		{
			throw new NotImplementedException ();
		}
	}
}

