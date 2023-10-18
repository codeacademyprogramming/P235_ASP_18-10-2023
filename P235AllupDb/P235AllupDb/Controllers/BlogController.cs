using Microsoft.AspNetCore.Mvc;

namespace P235AllupDb.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
