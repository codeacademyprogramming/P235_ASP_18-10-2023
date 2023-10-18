using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using Newtonsoft.Json;
using P235AllupDb.DataAccessLayer;
using P235AllupDb.Models;
using P235AllupDb.ViewModels;
using P235AllupDb.ViewModels.AccountVM;
using P235AllupDb.ViewModels.BasketVMs;

namespace P235AllupDb.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SmtpSetting _smtpSetting;
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public AccountController(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager, IOptions<SmtpSetting> options,
            IWebHostEnvironment enb, AppDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _smtpSetting = options.Value;
            _env = enb;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AppUser appUser = new AppUser
            {
                Name = model.Name,
                SurName = model.SurName,
                UserName = model.UserName,
                Email = model.Email,
                IsActive = true
            };

            IdentityResult identityResult = await _userManager.CreateAsync(appUser,model.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError identityError in identityResult.Errors)
                {
                    ModelState.AddModelError("", identityError.Description);
                }
                return View(model);
            }

            await _userManager.AddToRoleAsync(appUser, "Member");

            string templateFullPath = Path.Combine(_env.WebRootPath, "templates", "EmailConfirm.html");
            string templateContent = await System.IO.File.ReadAllTextAsync(templateFullPath);

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            string url = Url.Action("EmailConfirm", "Account", new { id = appUser.Id, token = token }, Request.Scheme, Request.Host.ToString());

            templateContent = templateContent.Replace("{{url}}", url);

            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(MailboxAddress.Parse(_smtpSetting.Email));
            mimeMessage.To.Add(MailboxAddress.Parse(appUser.Email));
            mimeMessage.Subject = "Email Confirm";
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = templateContent
            };

            using (SmtpClient client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpSetting.Host, _smtpSetting.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_smtpSetting.Email, _smtpSetting.Password);
                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
            }

            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            AppUser appUser = await _userManager.Users
                .Include(u=>u.Baskets.Where(b=>b.IsDeleted == false))
                .FirstOrDefaultAsync(u=>u.NormalizedEmail == loginVM.Email.Trim().ToUpperInvariant());
            if (appUser == null)
            {
                ModelState.AddModelError("", "Email Or Password Incorrect");
                return View(loginVM);
            }

            IList<string> roles= await _userManager.GetRolesAsync(appUser);
            if (!roles.Any(s=>s == "Member"))
            {
                ModelState.AddModelError("", "Email Or Password Incorrect");
                return View(loginVM);
            }

            if (!appUser.EmailConfirmed)
            {
                ModelState.AddModelError("", "Email Tesdiq Edin");
                return View(loginVM);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult =  await _signInManager
                .PasswordSignInAsync(appUser, loginVM.Password, loginVM.RememberMe, true);

            if (appUser.LockoutEnd != null && (appUser.LockoutEnd - DateTime.UtcNow).Value.Minutes > 0)
            {
                int date = (appUser.LockoutEnd - DateTime.UtcNow).Value.Minutes;

                ModelState.AddModelError("", $"Hesabiniz {date} deqiqe Bloklanib");
                return View(loginVM);
            }

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email Or Password Incorrect");
                return View(loginVM);
            }

            if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
            {
                List<BasketVM> basketVMs = new List<BasketVM>();
                foreach (Basket basket in appUser.Baskets)
                {
                    BasketVM basketVM = new BasketVM
                    {
                        Id = (int)basket.ProductId,
                        Count = basket.Count
                    };

                    basketVMs.Add(basketVM);
                }

                string cookie = JsonConvert.SerializeObject(basketVMs);
                Response.Cookies.Append("basket", cookie);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> EmailConfirm(string id, string token)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }

            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            if (!appUser.IsActive)
            {
                return BadRequest();
            }

            if (appUser.EmailConfirmed)
            {
                return Conflict();
            }

            IdentityResult identityResult = await _userManager.ConfirmEmailAsync(appUser, token);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError identityError in identityResult.Errors)
                {
                    ModelState.AddModelError("", identityError.Description);
                }

                return View(nameof(Login));
            }

            await _signInManager.SignInAsync(appUser, true);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles ="Member")]
        public async Task<IActionResult> Profile()
        {
            AppUser appUser = await _userManager.Users
               .Include(u => u.Addresses.Where(a => a.IsDeleted == false))
               .Include(u=>u.Orders.Where(o=>o.IsDeleted == false)).ThenInclude(o=>o.OrderProducts.Where(op=>op.IsDeleted == false))
               .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            ProfileVM profileVM = new ProfileVM();
            profileVM.Addresses = appUser.Addresses;
            profileVM.ProfileAccountVM = new ProfileAccountVM
            {
                Name = appUser.Name,
                SurName = appUser.SurName,
                Email = appUser.Email,
                UserName = appUser.UserName
            };
            profileVM.Orders = appUser.Orders;

            return View(profileVM);
        }

        [HttpPost]
        [Authorize(Roles ="Member")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProfileAccount(ProfileAccountVM profileAccountVM)
        {
            TempData["Tab"] = "Account";
            AppUser appUser = await _userManager.Users
               .Include(u => u.Addresses.Where(a => a.IsDeleted == false))
               .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            ProfileVM profileVM = new ProfileVM();
            profileVM.Addresses = appUser.Addresses;
            profileVM.ProfileAccountVM = profileAccountVM;

            if (!ModelState.IsValid)
            {
                return View("Profile", profileVM);
            }
           

            if (appUser.NormalizedUserName != profileAccountVM.UserName.Trim().ToUpperInvariant())
            {
                appUser.UserName = profileAccountVM.UserName;
            }
            if (appUser.NormalizedEmail != profileAccountVM.Email.Trim().ToUpperInvariant())
            {
                appUser.Email = profileAccountVM.Email;
            }

            appUser.Name = profileAccountVM.Name;
            appUser.SurName = profileAccountVM.SurName;

            IdentityResult identityResult = await _userManager.UpdateAsync(appUser);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError identityError in identityResult.Errors)
                {
                    ModelState.AddModelError("", identityError.Description);
                }
                return View("Profile", profileVM);
            }

            await _signInManager.SignInAsync(appUser, true);

            return RedirectToAction(nameof(Profile));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Member")]
        public async Task<IActionResult> AddAddress(Address address)
        {
            TempData["Tab"] = "Address";

            AppUser appUser = await _userManager.Users
               .Include(u => u.Addresses.Where(a => a.IsDeleted == false))
               .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            ProfileVM profileVM = new ProfileVM();
            profileVM.ProfileAccountVM = new ProfileAccountVM
            {
                Name = appUser.Name,
                SurName = appUser.SurName,
                Email = appUser.Email,
                UserName = appUser.UserName
            };
            profileVM.Addresses = appUser.Addresses;
            
            if (!ModelState.IsValid)
            {
                profileVM.Address = address;
                TempData["addreess"] = "true";
                return View("Profile", profileVM);
            }

            if (address.IsDefault == true)
            {
                if (appUser.Addresses != null && appUser.Addresses.Count() > 0)
                {
                    foreach (Address address1 in appUser.Addresses)
                    {
                        address1.IsDefault = false;
                    }
                }
            }
            else
            {
                if (appUser.Addresses == null || appUser.Addresses.Count() <= 0)
                {
                    address.IsDefault = true;
                }
            }

            address.UserId = appUser.Id;
            address.CreatedBy = appUser.Name + " " + appUser.SurName;
            address.CreatedAt = DateTime.Now;

            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Profile));
        }

        [HttpGet]
        [Authorize(Roles ="Member")]
        public async Task<IActionResult> EditAddress(int? id)
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            if (id == null)
            {
                return BadRequest();
            }

            Address address = await _context.Addresses.FirstOrDefaultAsync(a => a.IsDeleted == false && a.Id == id && a.UserId == appUser.Id);

            if (address == null) { return NotFound(); }


            return PartialView("_EditAddressPartial", address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> EditAddress(Address address)
        {
            TempData["Tab"] = "Address";
            AppUser appUser = await _userManager.Users
               .Include(u => u.Addresses.Where(a => a.IsDeleted == false))
               .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            ProfileVM profileVM = new ProfileVM();
            profileVM.ProfileAccountVM = new ProfileAccountVM
            {
                Name = appUser.Name,
                SurName = appUser.SurName,
                Email = appUser.Email,
                UserName = appUser.UserName
            };
            profileVM.Addresses = appUser.Addresses;

            if (!ModelState.IsValid)
            {
                profileVM.Address = address;
                TempData["editadress"] = "true";
                return View("Profile", profileVM);
            }

            Address dbAddress = appUser.Addresses.FirstOrDefault(a=>a.Id == address.Id);

            if (address.IsDefault == true)
            {
                if (appUser.Addresses != null && appUser.Addresses.Count() > 0)
                {
                    foreach (Address address1 in appUser.Addresses)
                    {
                        address1.IsDefault = false;
                    }
                }

                dbAddress.IsDefault = true;
            }
            else
            {
                if (appUser.Addresses == null || appUser.Addresses.Count() <= 0)
                {
                    dbAddress.IsDefault = true;
                }
            }

            dbAddress.Line1 = address.Line1;
            dbAddress.Line2 = address.Line2;
            dbAddress.Country = address.Country;
            dbAddress.Town = address.Town;
            dbAddress.State = address.State;
            dbAddress.PostalCode = address.PostalCode;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Profile));
        }
    }
}
