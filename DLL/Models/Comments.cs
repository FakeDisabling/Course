using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Comments
    {
        public int CommentsId { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public int GamesId { get; set; }
        public Games Games { get; set; }
    }
}
