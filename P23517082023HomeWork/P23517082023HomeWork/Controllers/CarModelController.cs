using Microsoft.AspNetCore.Mvc;
using P23517082023HomeWork.DataAccessLayer;
using P23517082023HomeWork.Models;

namespace P23517082023HomeWork.Controllers
{
    public class CarModelController : Controller
    {
        private readonly AppDbContext _context;

        public CarModelController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? id)
        {
            if (id != null &&  !_context.CarModels.Any(c=>c.BrandId == id)) return BadRequest("Id Is InCorrect");

            return View(_context.CarModels.Where(c=> id != null ? c.BrandId == id : true).ToList());
        }
    }
}
