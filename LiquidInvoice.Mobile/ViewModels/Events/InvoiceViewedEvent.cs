using System;
using ClassLibrary;
using Prism.Events;

namespace ViewModels
{
	public class InvoiceViewedEvent : PubSubEvent<InvoiceDto>
	{
	}
}

