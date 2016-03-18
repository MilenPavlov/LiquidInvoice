using System;
using System.Threading.Tasks;
using Interfaces;
using Prism.Events;

namespace ViewModels
{
	public class DashboardViewModel : IApplicationViewModel
	{
		IEventAggregator _eventAggregator;

		public DashboardViewModel (IEventAggregator eventAggregator)
		{
			_eventAggregator = eventAggregator;
		}

		public event ViewModelNavigationRequestHandler ViewModelNavigationRequested;

		public Task Start ()
		{
			throw new NotImplementedException ();
		}
	}
}

