using BLL.DTO;

namespace WebApplication1.Models
{
    public class GameViewModel
    {
        public string GameName { get; set; }
        public decimal Cost { get; set; }
        public string DescriptionGame { get; set; }
        public int ReleaseDate { get; set; }
        public string ImagePath { get; set; }
        public List<TypeGameDTO> GameTypes { get; set; }
    }
}
