using System;
using DataAcess;
using Interfaces;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace Services
{
	public class DependencyService : IDependencyService
	{
		private static IUnityContainer _dependencyContainer;

		public DependencyService()
		{
			_dependencyContainer = new UnityContainer();
			SetDependencies ();
		}


		private void SetDependencies ()
		{
			
			var eventAggregator = new EventAggregator (); 
			_dependencyContainer.RegisterInstance<IEventAggregator>(eventAggregator);
			_dependencyContainer.RegisterType<ISqliteConnectionService, SqliteConnectionService> ();
			_dependencyContainer.RegisterType<ICustomerRepository, CustomerRepository> ();
			_dependencyContainer.RegisterType<ICustomerService, CustomerService> ();
		}




		public T Resolve<T>()
		{

			return _dependencyContainer.Resolve<T>();

		}

		public void RegisterInstance<T>(T implementation)
		{
			_dependencyContainer.RegisterInstance<T>(implementation);
		}

		public void RegisterType<T, T1>() where T1 : T
		{
			_dependencyContainer.RegisterType<T, T1>();
		}
	}
}

