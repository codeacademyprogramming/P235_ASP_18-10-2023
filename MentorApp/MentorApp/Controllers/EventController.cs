using Microsoft.AspNetCore.Mvc;

namespace MentorApp.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.PageIndex = 5;

            return View();
        }
    }
}
