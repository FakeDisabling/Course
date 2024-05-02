using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DevelopersGamesDTO
    {
        public int Id { get; set; }
        public DevelopersDTO Developers { get; set; }
        public GamesDTO Games { get; set; }
        public int DevelopersId { get; set; }
        public int GamesId { get; set; }
    }
}
