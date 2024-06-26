﻿using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
		private readonly SignInManager<User> signInManager;
		private readonly UserManager<User> userManager;

		public LoginController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [HttpPost]
		public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    var user = await userManager.FindByNameAsync(model.Username);
                    HttpContext.Session.SetString("userId", user.Id);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }
        [HttpGet]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
		[HttpGet]
        public IActionResult Login() => View();

        public IActionResult Register() => View();
    }   
}
