using MentorApp.DataAccessLayer;
using MentorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentorApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.PageIndex = 3;

            return View(await _context.Courses
                .Include(c=>c.Trainer).ThenInclude(t=>t.Categroy)
                .Where(c=>c.IsDeleted == false)
                .ToListAsync()
                );
        }

        public async Task<IActionResult> Detatil(int? id)
        {
            if (id == null) return BadRequest();

            Course course = await _context.Courses
                .Include(c=>c.Trainer)
                .Include(c=>c.CourseSections.Where(cs=>cs.IsDeleted == false))
                .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);

            if (course == null) return NotFound();

            return View(course);
        }
    }
}
