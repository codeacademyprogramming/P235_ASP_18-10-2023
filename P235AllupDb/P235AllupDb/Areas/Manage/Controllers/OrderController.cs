using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P235AllupDb.DataAccessLayer;
using P235AllupDb.Enums;
using P235AllupDb.Models;
using P235AllupDb.Areas.Manage.ViewModels.OrderVMs;
using P235AllupDb.ViewModels;
using OrderVM = P235AllupDb.Areas.Manage.ViewModels.OrderVMs.OrderVM;

namespace P235AllupDb.Areas.Manage.Controllers
{
    [Authorize(Roles ="SuperAdmin, Admin")]
    [Area("Manage")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int currentPage = 1)
        {
            IQueryable<Order> queries = _context.Orders
                .Include(o=>o.OrderProducts.Where(op=>op.IsDeleted == false))
                .Where(o=>o.IsDeleted == false);

            return View(PageNatedList<Order>.Create(queries,currentPage,5,10));
        }


        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Order order = await _context.Orders
                .Include(o=>o.User)
                .Include(o=>o.OrderProducts.Where(op=>op.IsDeleted == false)).ThenInclude(op=>op.Product)
                .FirstOrDefaultAsync(o => o.IsDeleted == false && o.Id == id);

            if(order == null) return NotFound();

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(OrderVM orderVM)
        {
            Order dbOrder = await _context.Orders
                .Include(o=>o.User)
                .Include(o=>o.OrderProducts.Where(op=>op.IsDeleted == false)).ThenInclude(op=>op.Product)
                .FirstOrDefaultAsync(o => o.IsDeleted == false && o.Id == orderVM.Id);

            if (dbOrder == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View("Detail", dbOrder);
            }

            dbOrder.Comment = orderVM.Comment;
            dbOrder.Status = orderVM.Status;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
