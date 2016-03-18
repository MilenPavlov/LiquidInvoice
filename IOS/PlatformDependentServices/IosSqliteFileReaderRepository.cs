using System;
using System.IO;
using Foundation;
using Interfaces;

namespace MobileIOS
{
	public class IosSqliteFileReaderRepository : ISqliteFileReaderRepository
	{
		private string _filePath;

		public IosSqliteFileReaderRepository ()
		{
			string fileName = "LiquidInvoice.sqlite";
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = System.IO.Path.Combine(docFolder, "..", "Library", "Databases");
			_filePath = System.IO.Path.Combine(libFolder, fileName);

			if (!System.IO.Directory.Exists(libFolder))
			{
				System.IO.Directory.CreateDirectory(libFolder);
			}

			// Following code is required to Run in a simulator.  Each time the simulator launches a brand new file structure is created which requires a new copy to be copied over.
			var resourceDirectory = NSBundle.MainBundle.ResourcePath;
			var seedFile = Path.Combine (resourceDirectory, fileName);
			if (!File.Exists (_filePath))
			{
				File.Copy (seedFile, _filePath);
			}

			Console.WriteLine (_filePath);
		}

		#region ISqliteFileReaderRepository implementation

		public string FilePath
		{
			get
			{
				return _filePath;
			}
			set
			{
				this._filePath = value;
			}
		}

		#endregion
	}
}

