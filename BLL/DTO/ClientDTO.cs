using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ClientDTO
    {
        public int ClientId { get; set; }

        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public int ElectronicWallet { get; set; }
    }
}
