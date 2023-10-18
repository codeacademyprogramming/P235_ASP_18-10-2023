using Microsoft.AspNetCore.Mvc;

namespace P23516082023.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index(int age,string name)
        {
            return View();
        }
    }
}
