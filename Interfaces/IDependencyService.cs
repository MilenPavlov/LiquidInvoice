using System;

namespace Interfaces
{
	public interface IDependencyService
	{
		T Resolve<T>();
		void RegisterInstance<T>(T instance);
		void RegisterType<T, T1>() where T1 : T;
	}
}

