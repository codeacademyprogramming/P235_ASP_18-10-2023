using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using P235AllupDb.DataAccessLayer;
using P235AllupDb.Models;
using P235AllupDb.ViewModels;

namespace P235AllupDb.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int curentPage = 1)
        {
            IQueryable<Product> products = _context.Products
                .Where(p => p.IsDeleted == false)
                .OrderByDescending(p => p.Id);
            
            return View(PageNatedList<Product>.Create(products,curentPage,4,10));
        }

        public async Task<IActionResult> LoadMore(int? pageIndex)
        {
            if (pageIndex == null) return BadRequest();

            if(pageIndex <= 0) return BadRequest();

            IQueryable<Product> products = _context.Products
                .Where(p => p.IsDeleted == false)
                .OrderByDescending(p => p.Id);

            int maxPage = (int)Math.Ceiling((decimal)products.Count() / 12);

            if (pageIndex > maxPage) return BadRequest();

            products = products.Skip((int)pageIndex * 12).Take(12);

            //.Skip((int)pageIndex * 12)
            //    .Take(12)

            return PartialView("_LoadMorePartial",new List<Product>(products));
        }

        public async Task<IActionResult> Search(string search, int? categoryId)
        {
            List<Product> products = null;

            if (categoryId != null && await _context.Categories.AnyAsync(c=>c.IsDeleted == false && c.Id == categoryId))
            {
                products = await _context.Products
                .Where(p => p.IsDeleted == false && p.CategoryId == (int)categoryId || (
                p.Title.ToLower().Contains(search.ToLower()) ||
                p.Brand != null ? p.Brand.Name.ToLower().Contains(search.ToLower()) : true)
                ).ToListAsync();
            }
            else
            {
                products = await _context.Products
                .Where(p => p.IsDeleted == false ||  (
                p.Title.ToLower().Contains(search.ToLower()) ||
                p.Brand != null ? p.Brand.Name.ToLower().Contains(search.ToLower()) : true) ||
                p.Category.Name.ToLower().Contains(search.ToLower())
                ).ToListAsync();
            }

            return PartialView("_SearchPartial", products);

            //return Json(products);
        }

        public async Task<IActionResult> Modal(int? id)
        {
            if(id == null) return BadRequest("Id Is Not Be Null");

            Product product = await _context.Products
                .Include(p=>p.ProductImages.Where(pi=>pi.IsDeleted == false))
                .FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id == id);

            if(product == null) return NotFound("Id Is InCorrect");

            return PartialView("_ModalPartial", product);
        }

        
    }
}