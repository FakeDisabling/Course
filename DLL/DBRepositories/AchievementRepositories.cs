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
    public class AchievementRepositories : IAchievement
    {
        public ApplicationContext Database { get; set; }
        public AchievementRepositories (ApplicationContext Database)
        {
            this.Database = Database;
        }

        public void Add(Achievement entity)
        {
            Database.achievements.Add(entity);
            Database.SaveChanges();
        }

        public void Update(Achievement entity)
        {
            Database.achievements.Update(entity);
            Database.SaveChanges();
        }

        public void Delete(Achievement entity)
        {
            Database.achievements.Remove(entity);
            Database.SaveChanges();
        }

        public Achievement GetById(int id) => (Achievement)Database.achievements.Where(achievement => achievement.AchievementId == id);

        public IEnumerable<Achievement> GetAll() => Database.achievements.AsQueryable().AsNoTracking();
    }
}
