using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FinancialController : Controller
    {
        private IClientService clientService;
        private ICartService cartService;
        private IGamesService gamesService;
        private IStoreService storeService;

        public FinancialController(IClientService clientService, ICartService cartService, IGamesService gamesService,
            IStoreService storeService)
        {
            this.clientService = clientService;
            this.cartService = cartService;
            this.gamesService = gamesService;
            this.storeService = storeService;
        }
        public IActionResult Wallet()
        {
            string userId = HttpContext.Session.GetString("userId");

            List<ClientDTO> clientDTOs = clientService.GetAll();
            ClientDTO client = clientDTOs.Where(x => x.UserId == userId).FirstOrDefault();

            ViewBag.Client = client;
            return View("~/Views/Shop/Wallet.cshtml");
        }

        public IActionResult Replenishment(int cost)
        {
            ViewBag.Cost = cost;

            return View("~/Views/Shop/Replenishment.cshtml");
        }
        public IActionResult Payment()
        {
            return View("~/Views/Shop/Payment.cshtml");
        }

        public IActionResult UpdateElectronicWallet(ReplenishmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userId = HttpContext.Session.GetString("userId");

                List<ClientDTO> clientDTOs = clientService.GetAll();
                ClientDTO client = clientDTOs.Where(x => x.UserId == userId).FirstOrDefault();

                client.ElectronicWallet += model.Cost;
                clientService.Update(client);

                return RedirectToAction("Index", "Home");
            }
            return View("~/Views/Shop/Replenishment.cshtml");
        }
        public IActionResult BuyGames(CardViewModel cardViewModel)
        {
            if (ModelState.IsValid)
            {
                string userId = HttpContext.Session.GetString("userId");
                int total = (int)HttpContext.Session.GetInt32("total");

                List<ClientDTO> clientDTOs = clientService.GetAll();
                ClientDTO client = clientDTOs.Where(x => x.UserId == userId).FirstOrDefault();


                if (client.ElectronicWallet > total)
                {
                    List<CartDTO> listcart = cartService.GetAll();
                    List<CartDTO> cartListOfClient = listcart
                                .Where(x => x.ClientId == client.ClientId)
                                .ToList();

                    List<StoreDTO> stores = (from store in cartListOfClient
                                             join game in gamesService.GetAll() on store.GameId equals game.GamesId
                                             select new StoreDTO
                                             {
                                                 GamesId = game.GamesId,
                                                 ClientId = client.ClientId
                                             }).ToList();

                    foreach (var store in stores)
                    {
                        storeService.Add(store);
                    }
                    client.ElectronicWallet -= total;
                    clientService.Update(client);
                    foreach (var cart in cartListOfClient)
                    {
                        cartService.DeleteById(cart);
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View("~/Views/Shop/Payment.cshtml");
        }
    }
}
