using Microsoft.AspNetCore.Mvc;

namespace MentorApp.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.PageIndex = 2;
            return View();
        }
    }
}
