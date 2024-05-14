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
    public class CartRepositories : ICart
    {
        public ApplicationContext Database { get; set; }
        public CartRepositories(ApplicationContext Database)
        {
            this.Database = Database;
        }
        public void Add(Cart entity)
        {
            Database.carts.Add(entity);
            Database.SaveChanges();
        }

        public void Delete(Cart entity)
        {
            Database.carts.Remove(entity);
            Database.SaveChanges();
        }

        public IEnumerable<Cart> GetAll() => Database.carts.AsQueryable().AsNoTracking();

        public Cart GetById(int id) => (Cart)Database.carts.Where(Cart => Cart.CartId == id);

        public void Update(Cart entity)
        {
            Database.carts.Update(entity);
            Database.SaveChanges();
        }
    }
}
