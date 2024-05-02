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
    public class GamesRepositories : IGames
    {
        public ApplicationContext Database { get; set; }
        public GamesRepositories(ApplicationContext Database)
        {
            this.Database = Database;
        }
        public void Add(Games entity)
        {
            Database.games.Add(entity);
            Database.SaveChanges();
        }

        public void Delete(Games entity)
        {
            Database.games.Remove(entity);
            Database.SaveChanges();
        }

        public IEnumerable<Games> GetAll() => Database.games.AsQueryable().AsNoTracking();

        public Games GetById(int id) => Database.games.FirstOrDefault(games => games.GamesId == id);

        public void Update(Games entity)
        {
            Database.games.Update(entity);
            Database.SaveChanges();
        }
    }
}
