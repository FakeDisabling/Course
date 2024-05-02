using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace BLL.Mappers
{
    class AchievementProfile : Profile
    {
        public AchievementProfile()
        {
            CreateMap<AchievementUser, AchievementUserDTO>().ReverseMap();
        }
    }
}
