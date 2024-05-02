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
    public class AchievementUsersProfile : Profile
    {
        public AchievementUsersProfile()
        {
            CreateMap<AchievementUser, AchievementUserDTO>().ReverseMap();
        } 
    }
}
