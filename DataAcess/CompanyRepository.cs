using System;
using ClassLibrary;
using DataAccess;
using Interfaces;

namespace DataAcess
{
	public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
	{
		public CompanyRepository (ISqliteConnectionService context) : base(context)
		{
		}
	}
}

