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
    public class UserRepositories : IUser
    {
        public ApplicationContext Database { get; set; }
        public UserRepositories(ApplicationContext Database)
        {
            this.Database = Database;
        }
        public void Add(User entity)
        {
            Database.users.Add(entity);
            Database.SaveChanges();
        }

        public void Delete(User entity)
        {
            Database.users.Remove(entity);
            Database.SaveChanges();
        }

        public IEnumerable<User> GetAll() => Database.users.AsQueryable().AsNoTracking();

        public User GetById(string id) => (User)Database.users.Where(user => user.Id == id);

        public void Update(User entity)
        {
            Database.users.Update(entity);
            Database.SaveChanges();
        }
    }
}
