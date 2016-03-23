using System;
using Interfaces;

namespace DataAcess
{
	public class SqliteFileReaderRepository : ISqliteFileReaderRepository
	{
		string _filePath;

		public SqliteFileReaderRepository (string filePath)
		{
			_filePath = filePath;
		}

		public string FilePath
		{
			get
			{
				return _filePath;
			}

			set
			{
				_filePath = value;
			}
		}
	}
}

