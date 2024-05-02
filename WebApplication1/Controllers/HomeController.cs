using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ITypeGameService typeGame;
		private readonly IGamesService games;

		public HomeController(ILogger<HomeController> logger, ITypeGameService typeGame, IGamesService games)
		{
			_logger = logger;
			this.typeGame = typeGame;
			this.games = games;
		}

		public IActionResult Index()
		{
            List<TypeGameDTO> typeGameDTOs = typeGame.GetAll();
			List<GamesDTO> gamesDTOs = games.GetAll();
			List<GamesDTO> topsixList = games.TopSixGame();

			ViewBag.typeGameDTOs = typeGameDTOs;
			ViewBag.gameDTOs = gamesDTOs;
			ViewBag.topsixList = topsixList;
            return View();
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}