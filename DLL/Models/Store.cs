using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class Store
	{
		public int StoreId { get; set; }
		public int ClientId { get; set; }
		public Client Client { get; set; }
		public int GamesId { get; set; }
		public Games Games { get; set; }

		public Store()
		{

		}
	}
}
