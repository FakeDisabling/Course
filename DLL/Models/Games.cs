using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class Games
	{
		public int GamesId { get; set; }
		public string GameName { get; set; }
		public decimal Cost { get; set; }
		public string DescriptionGame { get; set; }
		public string ImagePath { get; set; }
		public int ReleaseDate { get; set; }
		public Games() {

		}
	}
}
