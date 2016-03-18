using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ClassLibrary;
using DataAccess;
using Interfaces;

namespace DataAcess
{
	public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
	{
		public CustomerRepository (ISqliteConnectionService context) : base(context)
		{
		}
	}
}

