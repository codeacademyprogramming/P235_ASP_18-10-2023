using Microsoft.AspNetCore.Mvc;

namespace P235AllupDb.Areas.Hr.Controllers
{
    [Area("hr")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
