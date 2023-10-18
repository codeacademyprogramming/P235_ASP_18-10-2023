using Microsoft.AspNetCore.Mvc;

namespace P235AllupDb.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
