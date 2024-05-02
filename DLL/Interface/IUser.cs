using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUser
    {
        void Add(User entity);
        void Update(User entity);
        void Delete(User entity);
        User GetById(string id);
        IEnumerable<User> GetAll();
    }
}
