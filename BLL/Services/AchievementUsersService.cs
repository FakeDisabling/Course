using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AchievementUsersService : IAchievementUserService
    {
        private IMapper achievementUserMapper;
        private IAchievementUser achievementUserService;

        public AchievementUsersService(IMapper achievementUserMapper, IAchievementUser achievementUserService)
        {
            this.achievementUserMapper = achievementUserMapper;
            this.achievementUserService = achievementUserService;
        }

        public void Add(AchievementUserDTO service)
        {
            var item = achievementUserMapper.Map<AchievementUser>(service);
            achievementUserService.Add(item);
        }

        public void DeleteById(AchievementUserDTO service)
        {
            var item = achievementUserMapper.Map<AchievementUser>(service);
            achievementUserService.Delete(item);
        }

        public AchievementUserDTO FindById(int id)
        {
            return achievementUserMapper.Map<AchievementUserDTO>(achievementUserService.GetById(id));
        }

        public List<AchievementUserDTO> GetAll()
        {
            return achievementUserMapper.Map<List<AchievementUserDTO>>(achievementUserService.GetAll());
        }

        public void Update(AchievementUserDTO service)
        {
            var item = achievementUserMapper.Map<AchievementUser>(service);
            achievementUserService.Update(item);
        }
    }
}
