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
    public class DevelopersGamesRepositories : IDevelopersGames
    {
        public ApplicationContext Database { get; set; }
        public DevelopersGamesRepositories(ApplicationContext Database)
        {
            this.Database = Database;
        }
        public void Add(DevelopersGames entity)
        {
            Database.developersGames.Add(entity);
            Database.SaveChanges();
        }

        public void Delete(DevelopersGames entity)
        {
            Database.developersGames.Remove(entity);
            Database.SaveChanges();
        }

        public IEnumerable<DevelopersGames> GetAll() => Database.developersGames.AsQueryable().AsNoTracking();

        public DevelopersGames GetById(int id) => (DevelopersGames)Database.developersGames.Where(developersGames => developersGames.DevelopersGamesId == id);

        public void Update(DevelopersGames entity)
        {
            Database.developersGames.Update(entity);
            Database.SaveChanges();
        }
    }
}
