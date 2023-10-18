using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using P235AllupDb.DataAccessLayer;
using P235AllupDb.Models;
using P235AllupDb.ViewModels.BasketVMs;

namespace P235AllupDb.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BasketController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id == null) return BadRequest("Id Is Not Be Null");

            if (!await _context.Products.AnyAsync(p=>p.IsDeleted == false && p.Id == id)) return NotFound("Id Is InCorrect");

            string? basket = Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(basket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

                if (basketVMs.Exists(b=>b.Id == id))
                {
                    basketVMs.Find(b => b.Id == id).Count += 1;
                }
                else
                {
                    basketVMs.Add(new BasketVM
                    {
                        Id = (int)id,
                        Count = 1
                    });
                }
            }
            else
            {
                basketVMs = new List<BasketVM> { new BasketVM
                    {
                        Id = (int)id,
                        Count = 1
                    } 
                };
            }

            basket = JsonConvert.SerializeObject(basketVMs);

            Response.Cookies.Append("basket", basket);

            if (User.Identity.IsAuthenticated && User.IsInRole("Member"))
            {
                AppUser appUser = await _userManager.Users
                    .Include(b=>b.Baskets.Where(b=>b.IsDeleted == false))
                    .FirstOrDefaultAsync(u=>u.UserName == User.Identity.Name);

                if (appUser != null && appUser.Baskets != null && appUser.Baskets.Count() > 0)
                {
                    Basket userBasket = appUser.Baskets.FirstOrDefault(b => b.ProductId == id);

                    if (userBasket != null)
                    {
                        userBasket.Count = basketVMs.FirstOrDefault(b => b.Id == id).Count;
                    }
                    else
                    {
                        Basket userNewBasket = new Basket
                        {
                            UserId = appUser.Id,
                            ProductId = id,
                            Count = basketVMs.FirstOrDefault(b => b.Id == id).Count
                        };

                        await _context.Baskets.AddAsync(userNewBasket);
                    }
                }
                else
                {
                    Basket userNewBasket = new Basket
                    {
                        UserId = appUser.Id,
                        ProductId = id,
                        Count = basketVMs.FirstOrDefault(b => b.Id == id).Count
                    };

                    await _context.Baskets.AddAsync(userNewBasket);
                }

                await _context.SaveChangesAsync();
            }

            foreach (BasketVM basketVM in basketVMs)
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.Id);

                basketVM.Title = product.Title;
                basketVM.Image = product.MainImage;
                basketVM.Price = product.DiscountedPrice > 0 ? product.DiscountedPrice : product.Price;
                basketVM.ExTax = product.ExTag;
            }

            return PartialView("_BasketPartial", basketVMs);
        }
    }
}
