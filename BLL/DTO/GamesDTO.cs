using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class GamesDTO
    {
        public int GamesId { get; set; }
        public string GameName { get; set; }
        public decimal Cost { get; set; }
        public string DescriptionGame { get; set; }
        public virtual ICollection<StoreDTO> Stores { get; set; } = new List<StoreDTO>();
        public string ImagePath { get; set; }
        public int ReleaseDate { get; set; }
        public bool IsModerate { get; set; }
    }
}
