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
    public class DevelopersGamesService : IDevelopersGamesService
    {
        private IMapper developersGamesMapper;
        private IDevelopersGames developerGamesService;
        private IDevelopersService developersService;

        public DevelopersGamesService(IMapper developersGamesMapper, IDevelopersGames developerGamesService, 
            IDevelopersService developersService)
        {
            this.developersGamesMapper = developersGamesMapper;
            this.developerGamesService = developerGamesService;
            this.developersService = developersService;
        }

        public void Add(DevelopersGamesDTO service)
        {
            var item = developersGamesMapper.Map<DevelopersGames>(service);
            developerGamesService.Add(item);
        }

        public void DeleteById(DevelopersGamesDTO service)
        {
            var item = developersGamesMapper.Map<DevelopersGames>(service);
            developerGamesService.Delete(item);
        }

        public DevelopersGamesDTO FindById(int id)
        {
            return developersGamesMapper.Map<DevelopersGamesDTO>(developerGamesService.GetById(id));
        }

        public List<DevelopersGamesDTO> GetAll()
        {
            return developersGamesMapper.Map<List<DevelopersGamesDTO>>(developerGamesService.GetAll());
        }

        public void Update(DevelopersGamesDTO service)
        {
            var item = developersGamesMapper.Map<DevelopersGames>(service);
            developerGamesService.Update(item);
        }

        public List<DevelopersDTO> GetAllDevelopers(int id)
        {
            List<DevelopersGamesDTO> developersDTOs = GetAll();
            var gamesTypeGameslist = GetAll();
            var developersList = developersService.GetAll();
            List<DevelopersDTO> typelist = gamesTypeGameslist
                .Where(x => x.GamesId == id)
                .Select(x => new DevelopersDTO
                {
                    DevelopersId = x.DevelopersId,
                    DevelopersName = developersList.FirstOrDefault(tg => tg.DevelopersId == x.DevelopersId).DevelopersName,
                    UserId = developersList.FirstOrDefault(tg => tg.DevelopersId == x.DevelopersId).UserId,
                    Description = developersList.FirstOrDefault(tg => tg.DevelopersId == x.DevelopersId).Description
                })
                .ToList();

            return typelist;
        }
    }
}
