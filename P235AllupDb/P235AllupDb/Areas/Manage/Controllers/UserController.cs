﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P235AllupDb.DataAccessLayer;
using P235AllupDb.Models;
using P235AllupDb.ViewModels;

namespace P235AllupDb.Areas.Manage.Controllers
{
    [Area("manage")]
    //[Authorize(Roles ="SuperAdmin")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index(int currentPage = 1)
        {
            List<AppUser> users =await _userManager.Users.Where(u=>u.UserName != User.Identity.Name).ToListAsync();

            foreach (var user in users) 
            {
               user.Roles = await _userManager.GetRolesAsync(user);
            }

            return View(PageNatedList<AppUser>.Create(users.AsQueryable(), currentPage, 5,8));
        }

        public async Task<IActionResult> SetActive(string? id,int currentPage)
        {
            if(string.IsNullOrWhiteSpace(id)) return BadRequest();

            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser == null) return NotFound();

            bool active = appUser.IsActive;

            appUser.IsActive = !active;

            await _userManager.UpdateAsync(appUser);

            List<AppUser> users = await _userManager.Users.Where(u => u.UserName != User.Identity.Name).ToListAsync();

            foreach (var user in users)
            {
                user.Roles = await _userManager.GetRolesAsync(user);
            }

            return PartialView("Mahmud", PageNatedList<AppUser>.Create(users.AsQueryable(), currentPage, 5, 8));
        }

        public async Task<IActionResult> ResetPassword(string id, int currentPage)
        {
            if (string.IsNullOrWhiteSpace(id)) return BadRequest();

            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser == null) return NotFound();

            string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);

            await _userManager.ResetPasswordAsync(appUser, token,"Welcome123");

            List<AppUser> users = await _userManager.Users.Where(u => u.UserName != User.Identity.Name).ToListAsync();

            foreach (var user in users)
            {
                user.Roles = await _userManager.GetRolesAsync(user);
            }

            return PartialView("Mahmud", PageNatedList<AppUser>.Create(users.AsQueryable(), currentPage, 5, 8));
        }
    }
}
