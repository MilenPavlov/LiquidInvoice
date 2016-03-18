using System;
using SQLite;

namespace Interfaces
{
	public interface ISqliteConnectionService
	{
		SQLiteAsyncConnection Instance { get; }
	} 
}

