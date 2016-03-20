using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;
using Services;
using DataAcess;
using ClassLibrary;

namespace UnitTests
{
    [TestClass]
    public class CreateDb
    {
        [TestMethod]
        public async Task CreateSqliteDb()
        {
            string file = "LiquidInvoice.sqlite";
            string directory = "C:\\tmp\\";
            string fullPath = directory + file;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            SqliteFileReaderRepository repository = new SqliteFileReaderRepository(fullPath);
            SqliteConnectionService db = new SqliteConnectionService(repository);
            var context = db.Instance;

            await context.CreateTableAsync<Invoice>();
            await context.CreateTableAsync<Customer>();
            await context.CreateTableAsync<Company>();
        }
    }
}
