using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DevelopersDTO
    {
        public int DevelopersId { get; set; }
        public string DevelopersName { get; set; }
        public string UserId { get; set; }
        public UserDTO User { get; set; }
        public string Description { get; set; }
    }
}
