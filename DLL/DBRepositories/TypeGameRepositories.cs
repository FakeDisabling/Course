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
    public class TypeGameRepositories : ITypeGame
    {
        public ApplicationContext Database { get; set; }
        public TypeGameRepositories(ApplicationContext Database)
        {
            this.Database = Database;
        }
        public void Add(TypeGame entity)
        {
            Database.typeGames.Add(entity);
            Database.SaveChanges();
        }

        public void Delete(TypeGame entity)
        {
            Database.typeGames.Remove(entity);
            Database.SaveChanges();
        }

        public IEnumerable<TypeGame> GetAll() => Database.typeGames.AsQueryable().AsNoTracking();

        public TypeGame GetById(int id) => (TypeGame)Database.typeGames.Where(typeGame => typeGame.TypeGameId == id);

        public void Update(TypeGame entity)
        {
            Database.typeGames.Update(entity);
            Database.SaveChanges();
        }
    }
}
