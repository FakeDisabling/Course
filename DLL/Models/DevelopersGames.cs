using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DevelopersGames
    {
        public int DevelopersGamesId {  get; set; }
        public int DevelopersId { get; set; }
        public Developers Developers { get; set; }
        public int GamesId { get; set; }
        public Games Games { get; set; }
        public DevelopersGames() { }
    }
}
