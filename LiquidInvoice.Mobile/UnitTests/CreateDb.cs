using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;
using Services;
using ClassLibrary;
using System.Collections.Generic;
using DataAcess;

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
            await context.CreateTableAsync<InvoiceType>();

            var companies = new List<Company>() {
                new Company() {
                    AccountNumber = "107-JA1",
                    Address = "702 S.W. Eighth St. Bentonville,	Arkansas",
                    Name = "Walmart",
                    Id = 1,
                    PhoneNumber = "928-382-5779",
                    LogoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcToBhhGyaPanYrQoDXGx3tvFy6OP0nPrGHNN5mJ7wmDwK1KmLVz7FJMstDP"
                },
                new Company() {
                    AccountNumber = "2A5-F3",
                    Address = "6001 Bollinger Canyon Rd. San Ramon,	California",
                    Name = "Phillips 66",
                    Id = 2,
                    PhoneNumber = "939-209-4719",
                    LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4c/Phillips66-Logo.svg/2000px-Phillips66-Logo.svg.png"
                },
                new Company() {
                    AccountNumber = "105-LL39",
                    Address = "3135 Easton Turnpike	Fairfield, Connecticut",
                    Name = "General Electric",
                    Id = 3,
                    PhoneNumber = "913-806-1173",
                    LogoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTHkVj_1qEduArejkXbIsK5Czt9_Y-xYypc4WrOVmiK2crY3LTGVmIupN0FuA"
                }
            };

            await context.InsertAllAsync(companies);

            var customers = new List<Customer>() {
                new Customer() {
                    Address = "123 Main street Boston, MA",
                    Id = 1,
                    PhoneNumber = "973-384-2902",
                    FirstName = "Jason",
                    LastName = "Feinkind"
                },
                new Customer() {
                    Address = "1212 West 14th Street New York, NY",
                    Id = 2,
                    PhoneNumber = "733-907-1404",
                    FirstName = "Mark",
                    LastName = "Feinkind"
                },
                 new Customer() {
                    Address = "34-14 Sanfernado Drive San Fransico, CA",
                    Id = 3,
                    PhoneNumber = "575-110-8477",
                    FirstName = "Denise",
                    LastName = "Feinkind"
                }
            };

            await context.InsertAllAsync(customers);

            var invoices = new List<Invoice>() {
                new Invoice() {
                    InvoiceTypeId = 1,
                    AmountDue = 3934.23m,
                    CompanyId = 1,
                    CustomerId = 1,
                    DueDate = DateTime.Now,
                    Id = 1
                },
                new Invoice() {
                    InvoiceTypeId = 2,
                    AmountDue = 12304.23m,
                    CompanyId = 2,
                    CustomerId = 2,
                    DueDate = DateTime.Now.AddDays(5),
                    Id = 2
                },
                 new Invoice() {
                     InvoiceTypeId = 2,
                    AmountDue = 879.96m,
                    CompanyId = 3,
                    CustomerId = 3,
                    DueDate = DateTime.Now.AddDays(-5),
                    Id = 3
                }
            };

            await context.InsertAllAsync(invoices);

            var invoiceTypes = new List<InvoiceType>() {
                new InvoiceType() {
                    FontSize = 16,
                    Id = 1,
                    LogoPosition = LogoPositionType.FullLength,
                    ShowPaymentOptions = true,
                    StretchLogo = true
                },
                new InvoiceType() {
                    FontSize = 17,
                    Id = 2,
                    LogoPosition = LogoPositionType.Right,
                    ShowPaymentOptions = false,
                    StretchLogo = false
                }
            };

            await context.InsertAllAsync(invoiceTypes);
        }
    }
}
