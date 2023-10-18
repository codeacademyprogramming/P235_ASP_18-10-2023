using MentorApp.DataAccessLayer;
using MentorApp.ViewModels.PricingVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentorApp.Controllers
{
    public class PricingController : Controller
    {
        private readonly AppDbContext _context;

        public PricingController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.PageIndex = 6;

            PricingVM pricingVM = new PricingVM
            {
                Pricings = await _context.Pricings
                .Include(p => p.PricingServices.Where(ps => ps.IsDeleted == false)).ThenInclude(ps=>ps.Service)
                .Where(p => p.IsDeleted == false).ToListAsync(),

                Services = await _context.Services.Where(s => s.IsDeleted == false).ToListAsync()
            };

            return View(pricingVM);
        }
    }
}
