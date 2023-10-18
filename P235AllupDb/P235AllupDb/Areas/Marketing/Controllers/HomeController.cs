using Microsoft.AspNetCore.Mvc;

namespace P235AllupDb.Areas.Marketing.Controllers
{
    [Area("marketing")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
