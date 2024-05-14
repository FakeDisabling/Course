using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public int GameId { get; set; }
        public GamesDTO Game { get; set; }
        public int ClientId { get; set; }
        public ClientDTO Client { get; set; }
    }
}
