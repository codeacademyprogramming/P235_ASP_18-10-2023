using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace P235AllupDb.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
