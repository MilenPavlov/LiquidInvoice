using System;
using SQLite;

namespace ClassLibrary
{
	public class Resource
	{
		[Column("Id"), Unique, PrimaryKey, AutoIncrement]
		public int Id { get; set; }
	}
}

