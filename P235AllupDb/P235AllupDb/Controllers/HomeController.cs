using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P235AllupDb.DataAccessLayer;
using P235AllupDb.Models;
using P235AllupDb.ViewModels.HomeVMs;

namespace P235AllupDb.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Sliders = await _context.Sliders.Where(s => s.IsDeleted == false).ToListAsync(),
                Categories = await _context.Categories.Where(c => c.IsDeleted == false && c.IsMain == true).ToListAsync(),
                NewArrival = await _context.Products.Where(p=>p.IsDeleted == false && p.IsNewArrival).ToListAsync(),
                BestSeller = await _context.Products.Where(p=>p.IsDeleted == false && p.IsBestSeller).ToListAsync(),
                Featured = await _context.Products.Where(p=>p.IsDeleted == false && p.IsFeatured).ToListAsync()
            };

            return View(homeVM);
        }

        public IActionResult SetCookie()
        {
            Response.Cookies.Append("P235FirstCookie", "P235 First Cookie");
            
            return Ok();
        }

        public IActionResult GetCookie()
        {
            string cookie = Request.Cookies["basket"];

            return Ok(cookie);
        }

        //public IActionResult SetSession()
        //{
        //    HttpContext.Session.SetString("P235FirstSession", "P235 Hello World");

        //    return Ok();
        //}

        //public IActionResult GetSession()
        //{
        //    string session = HttpContext.Session.GetString("P235FirstSession");

        //    return Ok(session);
        //}
    }
}
