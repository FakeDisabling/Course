using BLL.DTO;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class ProfileController : Controller
	{
		private readonly ITypeGameService typeGame;
		private readonly IUserService userService;
		private readonly UserManager<User> userManager;

		public ProfileController(ITypeGameService typeGame, IUserService userService, UserManager<User> userManager)
		{
			this.typeGame = typeGame;
			this.userService = userService;
			this.userManager = userManager;
		}
		public async Task<IActionResult> Profile()
		{
			List<TypeGameDTO> typeGameDTOs = typeGame.GetAll();
			string id = HttpContext.Session.GetString("userId");
			User user = await userManager.FindByIdAsync(id);

			ViewBag.typeGamesDTOs = typeGameDTOs;
			ViewBag.User = user;
            return View("~/Views/Information/Profile.cshtml");
		}

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] EditModel editModel)
        {
            if (ModelState.IsValid)
            {
                string userId = HttpContext.Session.GetString("userId");
                User user = await userManager.FindByIdAsync(userId);

                user.Email = editModel.Email;
                user.Birthday = editModel.Birthday;
                user.PhoneNumber = editModel.PhoneNumber;
                user.Address = editModel.Address;

                await userManager.UpdateAsync(user);

                ViewBag.User = user;

                return Json(new { success = true, data = editModel });
            }

            return Json(new { success = false });
        }
    }
}
