using System;
using SQLite;

namespace ClassLibrary
{
	public class Resource
	{
		[Column("Id")]
		public int Id { get; set; }
	}
}

