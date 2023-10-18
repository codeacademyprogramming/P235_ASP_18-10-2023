using MentorApp.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentorApp.Controllers
{
    public class TrainerController : Controller
    {
        private readonly AppDbContext _context;

        public TrainerController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.PageIndex = 4;

            return View(await _context.Trainers.Include(t=>t.Categroy)
                .Where(t=>t.IsDeleted == false).ToListAsync());
        }
    }
}
