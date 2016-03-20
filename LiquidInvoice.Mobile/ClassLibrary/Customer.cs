using System;
using SQLite;

namespace ClassLibrary
{
	public class Customer : Resource
	{
		[Column("FirstName")]
		public string FirstName { get; set; }

		[Column("LastName")]
		public string LastName { get; set; }

		[Column("Address")]
		public string Address { get; set; }

		[Column("PhoneNumber")]
		public string PhoneNumber { get; set; }
	}
}

