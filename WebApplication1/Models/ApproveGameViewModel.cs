using BLL.DTO;

namespace WebApplication1.Models
{
    public class ApproveGameViewModel
    {
        public string GameName { get; set; }
        public decimal Cost { get; set; }
        public string DescriptionGame { get; set; }
        public int ReleaseDate { get; set; }
        public string ImagePath { get; set; }
        public string GameTypes { get; set; }
        public string Developers { get; set; }
        public int GamesId { get; set; }
    }
}
