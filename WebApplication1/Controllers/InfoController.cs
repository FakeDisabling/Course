using BLL.DTO;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class InfoController : Controller
    {
        private readonly ITypeGameService typeGameService;
        private readonly IGamesService gamesService;
        private readonly IGamesTypesGamesService gamesTypesService;
        public InfoController(ILogger<HomeController> logger, ITypeGameService typeGame, IGamesService games,
            IGamesTypesGamesService gamesTypesService)
        {
            this.typeGameService = typeGame;
            this.gamesService = games;
            this.gamesTypesService = gamesTypesService;
        }
        [HttpPost]
        public IActionResult FindByGameName(SearchViewModel model)
        {
            if (model.GameName == null)
            {
                model.GameName = "";
            }
            List<GamesDTO> games = gamesService
                    .GetAll()
                    .Where(x => x.GameName.ToLower().Contains(model.GameName.ToLower()))
                    .ToList();

            ViewBag.games = games;
            ViewBag.count = games.Count();
            return View("~/Views/Information/SearchName.cshtml");
        }

        public IActionResult FindByTypeGame(int typeId) 
        {
            int TypeGameId = typeId;
            List<GamesDTO> games = gamesService.GetAll();
            List<GamesTypeGamesDTO> gamesTypeGames = gamesTypesService.GetAll();

			return View("~/Views/Information/SearchName.cshtml");
		}
    }
}
