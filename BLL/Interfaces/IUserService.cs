using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void Add(UserDTO service);
        void Update(UserDTO service);
        void DeleteById(UserDTO item);
        UserDTO FindById(string id);

        List<UserDTO> GetAll();
    }
}
