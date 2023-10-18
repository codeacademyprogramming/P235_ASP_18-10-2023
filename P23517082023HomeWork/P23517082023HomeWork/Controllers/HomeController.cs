using Microsoft.AspNetCore.Mvc;
using P23517082023HomeWork.DataAccessLayer;
using P23517082023HomeWork.Models;

namespace P23517082023HomeWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Brands.ToList());
        }
    }
}
