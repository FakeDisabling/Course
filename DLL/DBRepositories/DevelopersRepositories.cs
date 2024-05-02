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
    public class DevelopersRepositories : IDevelopers
    {
        public ApplicationContext Database { get; set; }
        public DevelopersRepositories(ApplicationContext Database)
        {
            this.Database = Database;
        }
        public void Add(Developers entity)
        {
            Database.developers.Add(entity);
            Database.SaveChanges();
        }

        public void Delete(Developers entity)
        {
            Database.developers.Remove(entity);
            Database.SaveChanges();
        }

        public IEnumerable<Developers> GetAll() => Database.developers.AsQueryable().AsNoTracking();

        public Developers GetById(int id) => (Developers)Database.developers.Where(developers => developers.DevelopersId == id);

        public void Update(Developers entity)
        {
            Database.developers.Update(entity);
            Database.SaveChanges();
        }
    }
}
