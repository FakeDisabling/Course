using DAL.DBContext;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBRepositories
{
    public class AchievementUserRepositories : IAchievementUser
    {
        public ApplicationContext Database { get; set; }
        public AchievementUserRepositories(ApplicationContext Database)
        {
            this.Database = Database;
        }
        public void Add(AchievementUser entity)
        {
            Database.achievementUsers.Add(entity);
            Database.SaveChanges();
        }

        public void Delete(AchievementUser entity)
        {
            Database.achievementUsers.Remove(entity);
            Database.SaveChanges();
        }

        public IEnumerable<AchievementUser> GetAll() => Database.achievementUsers.AsQueryable().AsNoTracking();

        public AchievementUser GetById(int id) => (AchievementUser)Database.achievementUsers.Where(achievementUsers => achievementUsers.AchievementUserId == id);

        public void Update(AchievementUser entity)
        {
            Database.achievementUsers.Update(entity);
            Database.SaveChanges();
        }
    }
}
