using BLL.DTO;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITypeGameService typeGame;
        private readonly IGamesService gamesService;
        private readonly IGamesTypesGamesService gamesTypesGamesService;
        private readonly IDevelopersGamesService devlopersGamesService;

        public GameController(ILogger<HomeController> logger, ITypeGameService typeGame, IGamesService games,
            IGamesTypesGamesService gamesTypesGamesService, IDevelopersGamesService developersGamesService)
        {
            _logger = logger;
            this.typeGame = typeGame;
            this.gamesService = games;
            this.gamesTypesGamesService = gamesTypesGamesService;
            this.devlopersGamesService = developersGamesService;
        }
        public IActionResult Game(int gameId)
        {
            List<TypeGameDTO> typeGameDTOs = typeGame.GetAll();
            GamesDTO gamesDTO = gamesService.FindById(gameId);
            List<TypeGameDTO> gamesTypeList = gamesTypesGamesService.GetAllTypeOfGame(gameId);
            List<DevelopersDTO> developersDTOs = devlopersGamesService.GetAllDevelopers(gameId);

            string gameTypeName = String.Join(",", gamesTypeList.Select(x => x.Type));
            string developersName = String.Join(",", developersDTOs.Select(x => x.DevelopersName));

            ViewBag.typeGamesDTOs = typeGameDTOs;
            ViewBag.gamesDTO = gamesDTO;
            ViewBag.gamesTypeList = gameTypeName;
            ViewBag.developersList = developersName;
            return View();
        }
    }
}
