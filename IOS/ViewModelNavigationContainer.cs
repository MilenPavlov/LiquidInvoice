using System;
using Foundation;
using Interfaces;

namespace MobileIOS
{
	public class ViewModelNavigationContainer : NSObject
	{
		public ViewModelNavigationContainer ()
		{
		}

		public IApplicationViewModel TargetViewModel{ get; set; }
	}
}

