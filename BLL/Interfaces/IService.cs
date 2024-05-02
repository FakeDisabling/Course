using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        void Add(T service);
        void Update(T service);
        void DeleteById(T item);
        T FindById(int id);
        List<T> GetAll();
    }
}
