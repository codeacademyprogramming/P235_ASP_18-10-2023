using Microsoft.AspNetCore.Mvc;

namespace MentorApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.PageIndex = 1;

            return View();
        }
    }
}
