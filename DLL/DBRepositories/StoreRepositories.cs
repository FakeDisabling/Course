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
    public class StoreRepositories : IStore
    {
        public ApplicationContext Database { get; set; }
        public StoreRepositories(ApplicationContext Database)
        {
            this.Database = Database;
        }
        public void Add(Store entity)
        {
            Database.stores.Add(entity);
            Database.SaveChanges();
        }

        public void Delete(Store entity)
        {
            Database.stores.Remove(entity);
            Database.SaveChanges();
        }

        public IEnumerable<Store> GetAll() => Database.stores.AsQueryable().AsNoTracking();

        public Store GetById(int id) => (Store)Database.stores.Where(store => store.StoreId == id);

        public void Update(Store entity)
        {
            Database.stores.Update(entity);
            Database.SaveChanges();
        }
    }
}
