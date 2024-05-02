using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CommentsDTO
    {
        public int CommentsId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public int GamesId { get; set; }
        public GamesDTO Games { get; set; }
    }
}
