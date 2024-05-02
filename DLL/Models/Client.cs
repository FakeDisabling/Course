using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class Client
	{
		public int ClientId { get; set; }

		public string UserId { get; set; }
		public User User { get; set; }
		public int ElectronicWallet { get; set; }

		public Client() { }
	}
}
