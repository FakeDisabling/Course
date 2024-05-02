using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class AchievementUserDTO
    {
        public int Id { get; set; }
        public AchievementUserDTO Achievement { get; set; }
        public UserDTO User { get; set; }
        public int UserId { get; set; }
        public int AchievementId { get; set; }
    }
}
