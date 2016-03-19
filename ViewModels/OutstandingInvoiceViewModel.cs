using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using Interfaces;

namespace ViewModels
{
	public class OutstandingInvoiceViewModel : IApplicationViewModel
	{
		List<Invoice> _outstandingInvoices;

		public OutstandingInvoiceViewModel ()
		{
		}

		public event ViewModelNavigationRequestHandler ViewModelNavigationRequested;

		public async Task Start ()
		{
			// do real stuff instead
			await Task.Run (() => {
				
				List<Invoice> dtos = new List<Invoice> ();

				Random rand = new Random ();

				for (int counter = 0; counter < 10; counter++)
				{
					var dto = new Invoice ();
					dto.AmountDue = Convert.ToDecimal(10000 * rand.NextDouble ());
					dto.DueDate = DateTime.Now.AddDays ((rand.Next () % 14) - 7);
					dto.CompanyName = CompanyNames.ElementAt (rand.Next () % CompanyNames.Count ());
					dto.LogoUrl = Urls.ElementAt (rand.Next () % Urls.Count ());

					dtos.Add (dto);
				}

				_outstandingInvoices = dtos;
			});
		}

		public List<Invoice> OutstandingInvoices
		{
			get
			{
				return _outstandingInvoices;
			}
		}

		private readonly IEnumerable<string> CompanyNames = new List<string> () {
			"Busta Movin’ Company",
			"Career Cast" ,
			"KICK- Knowledge and Information Control Kiosks" ,
			"Cipromox" ,
			"Flumbo " ,
			"Immunics " ,
			"KidZone Chatterbox " ,
			"Landmark Dental " ,
			"Legal Collections Agency " ,
			"Legal Recovery Agency of NY " ,
			"Legally Graphic " ,
			"LegCol"
		};

		private readonly IEnumerable<string> Urls = new List<string> () {
			"https://www.liquidinvoice.com/images/LighteningBolt.png",
			"https://www.liquidinvoice.com/images/PC.png" ,
			"https://www.liquidinvoice.com/images/Gears.png" ,
			"https://www.liquidinvoice.com/images/Display.jpg" 
		};
	}
}

