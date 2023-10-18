using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P23517082023HomeWork.DataAccessLayer;
using P23517082023HomeWork.Models;

namespace P23517082023HomeWork.Controllers
{
    public class CarController : Controller
    {
        private readonly AppDbContext _context;

        public CarController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id != null && !await _context.Cars.AnyAsync(c => c.CarModelId == id)) return BadRequest("Id Is InCorrect");

            return View(await _context.Cars.Where(c => id != null ? c.CarModelId == id : true).ToListAsync());
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Car car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);

            if (car == null) return NotFound();

            return View(car);
        }
    }
}
