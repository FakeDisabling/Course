using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITypeGameService typeGameService;
        private readonly IGamesService gamesService;
        private readonly IGamesTypesGamesService gamesTypesGamesService;
        private readonly IDevelopersGamesService devlopersGamesService;
        private readonly IDevelopersService developersService;
        public GameController(ILogger<HomeController> logger, ITypeGameService typeGame, IGamesService games,
            IGamesTypesGamesService gamesTypesGamesService, IDevelopersGamesService developersGamesService, IDevelopersService developersService)
        {
            _logger = logger;
            this.typeGameService = typeGame;
            this.gamesService = games;
            this.gamesTypesGamesService = gamesTypesGamesService;
            this.devlopersGamesService = developersGamesService;
            this.developersService = developersService;
        }
        public IActionResult Game(int gameId)
        {
            List<TypeGameDTO> typeGameDTOs = typeGameService.GetAll();
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
        public IActionResult DeveloperMenu()
        {
            return View("~/Views/Game/DeveloperMenu.cshtml");
        }

        public IActionResult ModeratorMenu()
        {
            List<GamesDTO> games = gamesService.GetAll().Where(x => x.IsModerate == false).ToList();
            List<DevelopersGamesDTO> developersGames = devlopersGamesService.GetAll();
            List<TypeGameDTO> typeGames = typeGameService.GetAll();
            List<DevelopersDTO> developers = developersService.GetAll();
            List<GamesTypeGamesDTO> gamesTypeList = gamesTypesGamesService.GetAll();

            var approveGameViewModelList = (from game in games
                                            select new ApproveGameViewModel
                                            {
                                                GamesId = game.GamesId,
                                                GameName = game.GameName,
                                                Cost = game.Cost,
                                                DescriptionGame = game.DescriptionGame,
                                                ReleaseDate = game.ReleaseDate,
                                                ImagePath = game.ImagePath,
                                                GameTypes = "",
                                                Developers = "",
                                            }).ToList();

            foreach (var game in approveGameViewModelList)
            {
                var gameTypeList = (from gameType in gamesTypeList
                                    join type in typeGames
                                    on gameType.TypeGameId equals type.TypeGameId
                                    where gameType.GamesId == game.GamesId
                                    select type.Type);
                game.GameTypes = string.Join(",", gameTypeList);

                var developerList = (from devGame in developersGames
                                     join dev in developers
                                     on devGame.DevelopersId equals dev.DevelopersId
                                     where devGame.GamesId == game.GamesId
                                     select dev.DevelopersName);
                game.Developers = string.Join(",", developerList);
            }




            ViewBag.approveGame = approveGameViewModelList;
            return View("~/Views/Game/ModeratorMenu.cshtml");
        }
        public IActionResult AddGameModerator(int gameId)
        {
            List<GamesDTO> games = gamesService.GetAll().Where(x => x.IsModerate == false).ToList();

            var findGame = games
                            .Where(x => x.GamesId == gameId)
                            .FirstOrDefault();

            if (findGame != null)
            {
                findGame.IsModerate = true;
                gamesService.Update(findGame);
            }

            return RedirectToAction("ModeratorMenu");
        }
        public IActionResult DeleteGame(int gameId)
        {
            List<GamesDTO> games = gamesService.GetAll().Where(x => x.IsModerate == false).ToList();

            var findGame = games
                            .Where(x => x.GamesId == gameId)
                            .FirstOrDefault();

            if (findGame != null)
            {
                List<DevelopersGamesDTO> developersGames = devlopersGamesService
                    .GetAll()
                    .Where(x => x.GamesId == findGame.GamesId)
                    .ToList();
                gamesService.DeleteById(findGame);

                foreach(var dev in developersGames)
                {
                    devlopersGamesService.DeleteById(dev);
                }
            }

            return RedirectToAction("ModeratorMenu");
        }
    }
}
