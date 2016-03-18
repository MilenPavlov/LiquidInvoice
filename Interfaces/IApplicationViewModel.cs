using System;
using System.Threading.Tasks;

namespace Interfaces
{
	public interface IApplicationViewModel
	{
		Task Start();
		event ViewModelNavigationRequestHandler ViewModelNavigationRequested;
	}

	public delegate void ViewModelNavigationRequestHandler(IApplicationViewModel viewModel);
}

