using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDevelopersGamesService : IService<DevelopersGamesDTO>
    {
        List<DevelopersDTO> GetAllDevelopers(int id);
    }
}
