using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class StoreDTO
    {
        public int StoreId { get; set; }
        public int ClientId { get; set; }
        public ClientDTO Client { get; set; }
        public int GamesId { get; set; }
        public GamesDTO Games { get; set; }
    }
}
