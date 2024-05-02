using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
