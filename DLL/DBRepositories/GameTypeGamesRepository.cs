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
    public class GameTypeGamesRepository : IGamesTypeGames
    {
        public ApplicationContext Database { get; set; }
        public GameTypeGamesRepository(ApplicationContext Database)
        {
            this.Database = Database;
        }

        public void Add(GamesTypeGames entity)
        {
            Database.gamesTypeGames.Add(entity);
            Database.SaveChanges();
        }

        public void Update(GamesTypeGames entity)
        {
            Database.gamesTypeGames.Update(entity);
            Database.SaveChanges();
        }

        public void Delete(GamesTypeGames entity)
        {
            Database.gamesTypeGames.Remove(entity);
            Database.SaveChanges();
        }

        public GamesTypeGames GetById(int id) => (GamesTypeGames)Database.gamesTypeGames.Where(GamesTypeGames => GamesTypeGames.GamesTypeGamesId == id);

        public IEnumerable<GamesTypeGames> GetAll() => Database.gamesTypeGames.AsQueryable().AsNoTracking();
    }
}
