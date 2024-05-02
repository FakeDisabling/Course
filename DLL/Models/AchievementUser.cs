using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class AchievementUser
    {
        public int AchievementUserId { get; set; }
        public int AchievementId { get; set; }
        public Achievement Achievement { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public AchievementUser() { }
    }
}
