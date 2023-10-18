using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P235AllupDb.DataAccessLayer;

namespace P235AllupDb.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Dictionary<string, string> asdsad)
        {
            //Dictionary<string, string> settings = await _context.Settings.ToDictionaryAsync(s=>s.Key, s => s.Value);

            return View(asdsad);
        }
    }
}
