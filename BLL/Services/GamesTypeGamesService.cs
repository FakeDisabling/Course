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
    public class GamesTypeGamesService : IGamesTypesGamesService
    {
		private IMapper gamesTypesGamesMapper;
		private IGamesTypeGames gamesTypesGamesService;
		private ITypeGameService typeGameService;

		public GamesTypeGamesService(IMapper gamesTypesGamesMapper, IGamesTypeGames gamesTypesGamesService,
			ITypeGameService typeGameService)
		{
			this.gamesTypesGamesMapper = gamesTypesGamesMapper;
			this.gamesTypesGamesService = gamesTypesGamesService;
			this.typeGameService = typeGameService;
		}

		public void Add(GamesTypeGamesDTO service)
		{
			var item = gamesTypesGamesMapper.Map<GamesTypeGames>(service);
			gamesTypesGamesService.Add(item);
		}

		public void DeleteById(GamesTypeGamesDTO service)
		{
			var item = gamesTypesGamesMapper.Map<GamesTypeGames>(service);
			gamesTypesGamesService.Delete(item);
		}

		public GamesTypeGamesDTO FindById(int id)
		{
			return gamesTypesGamesMapper.Map<GamesTypeGamesDTO>(gamesTypesGamesService.GetById(id));
		}

		public List<GamesTypeGamesDTO> GetAll()
		{
			return gamesTypesGamesMapper.Map<List<GamesTypeGamesDTO>>(gamesTypesGamesService.GetAll());
		}

		public void Update(GamesTypeGamesDTO service)
		{
			var item = gamesTypesGamesMapper.Map<GamesTypeGames>(service);
			gamesTypesGamesService.Update(item);
		}
		public List<TypeGameDTO> GetAllTypeOfGame(int id)
		{
			var gamesTypeGameslist = GetAll();
			var typeGame = typeGameService.GetAll();
            List<TypeGameDTO> typelist = gamesTypeGameslist
				.Where(x => x.GamesId == id)
				.Select(x => new TypeGameDTO
				{
					TypeGameId = x.TypeGameId,
					Type = typeGame.FirstOrDefault(tg => tg.TypeGameId == x.TypeGameId)?.Type
				})
				.ToList();

            return typelist;
        }
	}
}
