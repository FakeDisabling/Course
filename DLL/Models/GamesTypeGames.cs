using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class GamesTypeGames
    {
        public int GamesTypeGamesId { get; set; }
        public Games Games { get; set; }
        public int GamesId { get; set; }
        public TypeGame TypeGame { get; set; }
        public int TypeGameId { get; set; }
    }
}
