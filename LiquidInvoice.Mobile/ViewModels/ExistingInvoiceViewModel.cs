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
		IEventAggregator _eventAggregator;

		public ExistingInvoiceViewModel (IEventAggregator eventAggregator)
		{
			_eventAggregator = eventAggregator;
		}

		public event ViewModelNavigationRequestHandler ViewModelNavigationRequested;

		public Task Start ()
		{
			_eventAggregator.GetEvent<InvoiceViewedEvent> ().Publish (_invoice);

			return Task.FromResult (0);
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

