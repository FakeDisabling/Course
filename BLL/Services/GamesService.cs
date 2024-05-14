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
    public class GamesService : IGamesService
    {
        private IMapper gamesMapper;
        private IGames gamesService;

        public GamesService(IMapper gamesMapper, IGames gamesService)
        {
            this.gamesMapper = gamesMapper;
            this.gamesService = gamesService;
        }

        public void Add(GamesDTO service)
        {
            var item = gamesMapper.Map<Games>(service);
            gamesService.Add(item);
        }

        public void DeleteById(GamesDTO service)
        {
            var item = gamesMapper.Map<Games>(service);
            gamesService.Delete(item);
        }

        public GamesDTO FindById(int id)
        {
            return gamesMapper.Map<GamesDTO>(gamesService.GetById(id));
        }

        public List<GamesDTO> GetAll()
        {
            return gamesMapper.Map<List<GamesDTO>>(gamesService.GetAll());
        }

        public void Update(GamesDTO service)
        {
            var item = gamesMapper.Map<Games>(service);
            gamesService.Update(item);
        }
        
        public List<GamesDTO> TopSixGame()
        {
            List<GamesDTO> gamesDTOs = GetAll().Where(x => x.IsModerate == true).ToList();
            return gamesDTOs.Take(6).ToList();
        }
    }
}
