using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class GamesTypeGamesDTO
    {
        public int GamesTypeGamesId { get; set; }
        public GamesDTO Games { get; set; }
        public int GamesId { get; set; }
        public TypeGameDTO TypeGame { get; set; }
        public int TypeGameId { get; set; }
    }
}
