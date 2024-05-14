using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int GameId { get; set; }
        public Games Game { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
