
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using P235AllupDb.Areas.Manage.ViewModels.AccountVMs;
using P235AllupDb.DataAccessLayer;
using P235AllupDb.Models;
using P235AllupDb.ViewModels;

namespace P235AllupDb.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManage;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;
        private readonly SmtpSetting _smtpSetting;
        private readonly IWebHostEnvironment _env;

        public AccountController(UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> roleManage, 
            SignInManager<AppUser> signInManager, 
            IConfiguration config, 
            IOptions<SmtpSetting> options,
            IWebHostEnvironment env)
        {
            _userManager = userManager;
            _roleManage = roleManage;
            _signInManager = signInManager;
            _config = config;
            _smtpSetting = options.Value;
            _env = env;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(!ModelState.IsValid)
            {
                return View(registerVM);
            }

            AppUser appUser = new AppUser
            {
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                IsActive = true
            };

            #region Comment
            //if (await _userManager.Users.AnyAsync(u=>u.NormalizedUserName == registerVM.UserName.Trim().ToUpperInvariant()))
            //{
            //    ModelState.AddModelError("UserName", $"'{registerVM.UserName}' Already Exists");
            //    return View(registerVM);
            //}

            //if (await _userManager.Users.AnyAsync(u => u.NormalizedEmail == registerVM.Email.Trim().ToUpperInvariant()))
            //{
            //    ModelState.AddModelError("Email", $"'{registerVM.Email}' Already Exists");
            //    return View(registerVM);
            //}
            #endregion

            IdentityResult identityResult = await _userManager.CreateAsync(appUser,registerVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError identityError in identityResult.Errors)
                {
                    ModelState.AddModelError("", identityError.Description);
                }

                return View(registerVM);
            }

            await _userManager.AddToRoleAsync(appUser, "Admin");
            string templateFullPath = Path.Combine(_env.WebRootPath, "templates", "EmailConfirm.html");
            string templateContent =await System.IO.File.ReadAllTextAsync(templateFullPath);

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            string url = Url.Action("EmailConfirm","Account",new { id=appUser.Id,token = token},Request.Scheme,Request.Host.ToString());

            templateContent = templateContent.Replace("{{url}}", url);

            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(MailboxAddress.Parse(_smtpSetting.Email));
            //mimeMessage.From.Add(MailboxAddress.Parse(_config.GetSection("SmtpSetting:Email").Value));
            mimeMessage.To.Add(MailboxAddress.Parse(appUser.Email));
            mimeMessage.Subject = "Email Confirm";
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = templateContent
            }; 
            //mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            //{
            //    Text = $"Salam Email Tesdiq Et Link: {url}"
            //};

            using (SmtpClient client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpSetting.Host, _smtpSetting.Port, MailKit.Security.SecureSocketOptions.StartTls);
                //await client.ConnectAsync(_config.GetSection("SmtpSetting:Host").Value, int.Parse(_config.GetSection("SmtpSetting:Port").Value), MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_smtpSetting.Email, _smtpSetting.Password);
                //await client.AuthenticateAsync(_config.GetSection("SmtpSetting:Email").Value, _config.GetSection("SmtpSetting:Password").Value);
                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
                //client.Dispose();
            }

            #region Comment
            //cdceobmmclfraebx

            //string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

            //string url = Url.Action("EmailConfirm", "Account", new { id = appUser.Id, token = token },HttpContext.Request.Scheme,HttpContext.Request.Host.ToString());

            //MimeMessage mimeMessage = new MimeMessage();
            //mimeMessage.From.Add(MailboxAddress.Parse("p235codeacademy@gmail.com"));
            //mimeMessage.To.Add(MailboxAddress.Parse(appUser.Email));
            //mimeMessage.Subject = "Email Confirm";
            //mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            //{
            //    Text = $"{url}"
            //};

            //using(SmtpClient smtpClient = new SmtpClient())
            //{
            //    await smtpClient.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            //    await smtpClient.AuthenticateAsync("p235codeacademy@gmail.com", "46546546546546");
            //    await smtpClient.SendAsync(mimeMessage);
            //    await smtpClient.DisconnectAsync(true);
            //}
            #endregion

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

            AppUser appUser = await _userManager.FindByEmailAsync(loginVM.Email);

            if (appUser == null)
            {
                ModelState.AddModelError("", "Email Or Password Is InCorrect");
                return View(loginVM);
            }

            //if(!await _userManager.CheckPasswordAsync(appUser, loginVM.Password))
            //{
            //    ModelState.AddModelError("", "Email Or Password Is InCorrect");
            //    return View(loginVM);
            //}

            if (!appUser.IsActive)
            {
                return Unauthorized();
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult =  await _signInManager
                .PasswordSignInAsync(appUser, loginVM.Password, loginVM.RemindMe, true);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email Or Password Is InCorrect");
                return View(loginVM);
            }

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Hesabiniz Bloklanib");
                return View(loginVM);
            }

            return RedirectToAction("Index","Dashboard",new { area="manage"});
        }

        [HttpGet]
        [Authorize(Roles ="SuperAdmin,Admin")]
        public async Task<IActionResult> Profile()
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            if (appUser == null) return BadRequest();

            ProfileVM profileVM = new ProfileVM
            {
                Name = appUser.Name,
                SurName = appUser.SurName,
                Email = appUser.Email,
                UserName = appUser.UserName
            };

            return View(profileVM);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(ProfileVM profileVM)
        {
            if(!ModelState.IsValid) return View(profileVM);

            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            if (appUser.NormalizedUserName != profileVM.UserName.Trim().ToUpperInvariant())
            {
                appUser.UserName = profileVM.UserName.Trim();
            }

            if (appUser.NormalizedEmail != profileVM.Email.Trim().ToUpperInvariant())
            {
                appUser.Email = profileVM.Email.Trim();
            }
            
            appUser.Name = profileVM.Name;
            appUser.SurName = profileVM.SurName;

            IdentityResult identityResult = await _userManager.UpdateAsync(appUser);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError identityError in identityResult.Errors)
                {
                    ModelState.AddModelError("", identityError.Description);
                }
                return View(profileVM);
            }

            if (!string.IsNullOrWhiteSpace(profileVM.CurrentPassword))
            {
                if (!await _userManager.CheckPasswordAsync(appUser,profileVM.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "Current Password Is InCorrect");
                    return View(profileVM);
                }

                string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);

                identityResult = await _userManager.ResetPasswordAsync(appUser, token, profileVM.NewPassword);

                if (!identityResult.Succeeded)
                {
                    foreach (IdentityError identityError in identityResult.Errors)
                    {
                        ModelState.AddModelError("", identityError.Description);
                    }
                    return View(profileVM);
                }
            }

            await _signInManager.SignInAsync(appUser, true);

            return RedirectToAction("Index", "Dashboard", new { area = "manage" });
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(Login));
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

            //if (!appUser.IsActive)
            //{
            //    return BadRequest();
            //}

            //if (appUser.EmailConfirmed)
            //{
            //    return Conflict();
            //}

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

            return RedirectToAction("Index", "Dashboard", new { area = "manage" });
        }

        [HttpGet]
        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM forgotPasswordVM)
        {
            if (!ModelState.IsValid)
            {
                return View(forgotPasswordVM);
            }

            AppUser appUser = await _userManager.FindByEmailAsync(forgotPasswordVM.Email);

            if (appUser == null) 
            {
                ModelState.AddModelError("Email", "Email Is InCorrect");
                return View(forgotPasswordVM);
            }

            //if (!appUser.IsActive)
            //{
            //    ModelState.AddModelError("Email", "Email Is InCorrect");
            //    return View(forgotPasswordVM);
            //}

            string token =await _userManager.GeneratePasswordResetTokenAsync(appUser);
            string templateFullPath = Path.Combine(_env.WebRootPath, "templates", "ResetPassword.html");
            string templateContent =await System.IO.File.ReadAllTextAsync(templateFullPath);
            string url = Url.Action("ResetPassword", "Account", new { appUser.Id, token }, Request.Scheme, Request.Host.ToString());
            templateContent = templateContent.Replace("{{action_url}}", url);
            templateContent = templateContent.Replace("{{name}}", appUser.Email);

            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(MailboxAddress.Parse(_smtpSetting.Email));
            mimeMessage.To.Add(MailboxAddress.Parse(appUser.Email));
            mimeMessage.Subject = "Reset Password";
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = templateContent
            };

            using(SmtpClient client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpSetting.Host, _smtpSetting.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_smtpSetting.Email, _smtpSetting.Password);
                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
            }

            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string id, string token, ResetPasswordVM resetPasswordVM)
        {
            if(!ModelState.IsValid) return View(resetPasswordVM);

            if (string.IsNullOrWhiteSpace(id))
            {
                ModelState.AddModelError("", "Id Is InCorrect");
                return View(resetPasswordVM);
            }

            if (string.IsNullOrWhiteSpace(token))
            {
                ModelState.AddModelError("", "Token Is InCorrect");
                return View(resetPasswordVM);
            }

            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser == null)
            {
                ModelState.AddModelError("", "Id Is InCorrect");
                return View(resetPasswordVM);
            }

            IdentityResult identityResult = await _userManager.ResetPasswordAsync(appUser, token, resetPasswordVM.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError identityError in identityResult.Errors)
                {
                    ModelState.AddModelError("", identityError.Description);
                }

                return View(resetPasswordVM);
            }


            return RedirectToAction(nameof(Login));
        }
        #region Comment
        //[HttpGet]
        //public async Task<IActionResult> CreateSuperAdmin()
        //{
        //    AppUser appUser = new AppUser
        //    {
        //        Email = "superadmin@gmail.com",
        //        UserName = "superadmin"
        //    };

        //    await _userManager.CreateAsync(appUser, "SuperAdminP235");
        //    await _userManager.AddToRoleAsync(appUser, "SuperAdmin");

        //    return Ok("Super Admin Yarandi");

        //}

        //[HttpGet]
        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManage.CreateAsync(new IdentityRole("SuperAdmin"));
        //    await _roleManage.CreateAsync(new IdentityRole("Admin"));
        //    await _roleManage.CreateAsync(new IdentityRole("Member"));

        //    return Ok("Rolelar Yarandi");
        //}
        #endregion
    }
}
