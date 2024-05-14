using DAL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using BLL.DTO;
using DAL.Interface;
using AutoMapper;
using Microsoft.VisualBasic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        private IGamesService gamesService;
        private ICartService cartService;
        private IClientService clientService;
        private IStoreService storeService;
        public CartController(IGamesService gamesService, ICartService cartService, IClientService clientService, 
            IStoreService storeService)
        {
            this.gamesService = gamesService;
            this.cartService = cartService;
            this.clientService = clientService;
            this.storeService = storeService;
        }

        public IActionResult RemoveFromCart(int gameId)
        {
            List<CartDTO> listcart = cartService.GetAll();
            List<ClientDTO> clientDTOs = clientService.GetAll();

            string userId = HttpContext.Session.GetString("userId");
            ClientDTO client = clientDTOs.Where(x => x.UserId == userId).FirstOrDefault();

            var findCart = listcart
                            .Where(x => x.GameId == gameId && x.ClientId == client.ClientId)
                            .FirstOrDefault();

            if (findCart != null)
            {
                cartService.DeleteById(findCart);
            }

            return RedirectToAction("CheckCart");
        }
        public IActionResult AddToCart(int gameId)
        {
            List<CartDTO> listcart = cartService.GetAll();
            List<StoreDTO> stores = storeService.GetAll();
            List<ClientDTO> clientDTOs = clientService.GetAll();
            string userId = HttpContext.Session.GetString("userId");
            ClientDTO client = clientDTOs.Where(x => x.UserId == userId).FirstOrDefault();

            var checkCart = listcart
                            .Where(x => x.GameId == gameId && x.ClientId == client.ClientId)
                            .FirstOrDefault();

            var checkStore = stores
                            .Where(x => x.GamesId == gameId && x.ClientId == client.ClientId)
                            .FirstOrDefault();

            if (checkCart == null && checkStore == null)
            {
                CartDTO cart = new CartDTO();
                cart.ClientId = client.ClientId;
                cart.GameId = gameId;
                cartService.Add(cart);

                List<CartViewModel> selectedCart = (from cartDTO in cartService.GetAll()
                                                    where cartDTO.ClientId == client.ClientId
                                                    join game in gamesService.GetAll() on cartDTO.GameId equals game.GamesId
                                                    select new CartViewModel
                                                    {
                                                        GameName = game.GameName,
                                                        Cost = game.Cost,
                                                        GameId = game.GamesId
                                                    }).ToList();

                int total = (int)selectedCart.Sum(x => x.Cost);
                ViewBag.Cart = selectedCart;
                ViewBag.total = total;

                HttpContext.Session.SetInt32("total", total);

                return View("~/Views/Shop/Cart.cshtml");
            }
            return RedirectToAction("Game", "Game", new { gameId = gameId });
        }

        public IActionResult CheckCart()
        {
			string userId = HttpContext.Session.GetString("userId");
            List<CartDTO> cartDTOs = cartService.GetAll();
			List<ClientDTO> clientDTOs = clientService.GetAll();
			ClientDTO client = clientDTOs.Where(x => x.UserId == userId).FirstOrDefault();

			List<CartViewModel> selectedCart = (from cartDTO in cartService.GetAll()
												where cartDTO.ClientId == client.ClientId
												join game in gamesService.GetAll() on cartDTO.GameId equals game.GamesId
												select new CartViewModel
												{
													GameName = game.GameName,
													Cost = game.Cost,
                                                    GameId = game.GamesId
                                                }).ToList();

            int total = (int)selectedCart.Sum(x => x.Cost);
            ViewBag.Cart = selectedCart;
            ViewBag.total = total;

            HttpContext.Session.SetInt32("total", total);
            return View("~/Views/Shop/Cart.cshtml");
		}
    }
}
