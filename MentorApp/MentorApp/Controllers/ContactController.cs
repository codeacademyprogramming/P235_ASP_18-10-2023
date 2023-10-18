using Microsoft.AspNetCore.Mvc;

namespace MentorApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.PageIndex = 7;
            return View();
        }
    }
}
