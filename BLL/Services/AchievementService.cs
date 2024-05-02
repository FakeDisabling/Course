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
    public class AchievementService : IAchievementService
    {
        private IMapper achievementMapper;
        private IAchievement achievementService;

        public AchievementService(IMapper achievementMapper, IAchievement achievementService)
        {
            this.achievementMapper = achievementMapper;
            this.achievementService = achievementService;
        }

        public void Add(AchievementDTO service)
        {
            var item = achievementMapper.Map<Achievement>(service);
            achievementService.Add(item);
        }

        public void DeleteById(AchievementDTO service)
        {
            var item = achievementMapper.Map<Achievement>(service);
            achievementService.Delete(item);
        }

        public AchievementDTO FindById(int id)
        {
            return achievementMapper.Map<AchievementDTO>(achievementService.GetById(id));
        }

        public List<AchievementDTO> GetAll()
        {
            return achievementMapper.Map<List<AchievementDTO>>(achievementService.GetAll());
        }

        public void Update(AchievementDTO service)
        {
            var item = achievementMapper.Map<Achievement>(service);
            achievementService.Update(item);
        }
    }
}
