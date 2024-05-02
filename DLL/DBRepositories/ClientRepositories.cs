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
    public class ClientRepositories : IClient
    {
        public ApplicationContext Database { get; set; }
        public ClientRepositories(ApplicationContext Database)
        {
            this.Database = Database;
        }
        public void Add(Client entity)
        {
            Database.clients.Add(entity);
            Database.SaveChanges();
        }

        public void Delete(Client entity)
        {
            Database.clients.Remove(entity);
            Database.SaveChanges();
        }

        public IEnumerable<Client> GetAll() => Database.clients.AsQueryable().AsNoTracking();

        public Client GetById(int id) => (Client)Database.clients.Where(client => client.ClientId == id);

        public void Update(Client entity)
        {
            Database.clients.Update(entity);
            Database.SaveChanges();
        }
    }
}
