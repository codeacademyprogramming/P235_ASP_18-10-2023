﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P235AllupDb.DataAccessLayer;
using P235AllupDb.Models;
using P235AllupDb.ViewModels;

namespace P235AllupDb.Areas.Manage.Controllers
{
    [Area("manage")]
    //[Authorize]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int currentPage = 1)
        {
            IQueryable<Category> queries = _context.Categories
                .Include(c=>c.Products.Where(p=>p.IsDeleted == false))
                .Include(c=>c.Children.Where(p=>p.IsDeleted == false))
                .Where(c => c.IsDeleted == false && c.IsMain == true);

            return View(PageNatedList<Category>.Create(queries,currentPage,5,6));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Category category = await _context.Categories
                .Include(c => c.Products.Where(p => p.IsDeleted == false))
                .Include(c=>c.Children.Where(ch=>ch.IsDeleted == false)).ThenInclude(c => c.Products.Where(p => p.IsDeleted == false))
                .FirstOrDefaultAsync(c=>c.IsDeleted == false && c.Id == id);

            if(category == null) return NotFound(); 

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<Category> categories = await _context.Categories
                .Where(c => c.IsDeleted == false && c.IsMain == true)
                .ToListAsync();

            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            var ms  = new MemoryStream();
            category.File.CopyTo(ms);
            var a = ms.ToArray();
            var b = Convert.ToBase64String(a);

            List<Category> categories = await _context.Categories
               .Where(c => c.IsDeleted == false && c.IsMain == true)
               .ToListAsync();
            ViewBag.Categories = categories;

            if (!ModelState.IsValid) return View(category);

            if (category.IsMain)
            {
                if (category.File == null)
                {
                    ModelState.AddModelError("File", "File Is Required");
                    return View(category);
                }

                if (!category.File.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("File", "File Type Must Be .jpg Or .jpeg");
                    return View(category);
                }

                //if (category.File.ContentType != "image/jpeg" )
                //{
                //    ModelState.AddModelError("File", "File Type Must Be .jpg Or .jpeg");
                //    return View(category);
                //}

                if ((category.File.Length / 1024) > 30)
                {
                    ModelState.AddModelError("File", "File Type Must Be Maximum 30kb");
                    return View(category);
                }

                string fileName = DateTime.UtcNow.AddHours(4).ToString("yyyyMMddHHmmssfff")+category.File.FileName
                    .Substring(category.File.FileName.LastIndexOf('.'));

                string filePath = Path.Combine(_env.WebRootPath, "assets", "images", fileName);
                
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await category.File.CopyToAsync(fileStream);
                }
                
                category.Image = fileName;
                category.ParentId = null;

                #region Comment
                //int lastDotIndex = category.File.FileName.LastIndexOf('.');

                //string fileExtention = category.File.FileName.Substring(lastDotIndex);

                //string filePath = _env.WebRootPath+ @"\assets\images\"+fileName;
                //string filePath = "C:\\Users\\hamid.mammadov\\Desktop\\P235\\Project\\P235AllupDb\\P235AllupDb\\wwwroot\\assets\\images\\"+fileName;


                //FileStream fileStream = new FileStream(filePath, FileMode.Create);
                //try
                //{
                //    await category.File.CopyToAsync(fileStream);
                //}
                //finally 
                //{ 
                //    fileStream.Dispose(); 
                //}

                //if (string.IsNullOrWhiteSpace(category.Image))
                //{
                //    ModelState.AddModelError("Image", "Required");
                //    return View(category);
                //}
                #endregion
            }
            else
            {
                if (category.ParentId == null)
                {
                    ModelState.AddModelError("ParentId", "Required");
                    return View(category);
                }

                if (!await _context.Categories.AnyAsync(c=>c.IsDeleted == false && c.IsMain == true && c.Id == category.ParentId))
                {
                    ModelState.AddModelError("ParentId", "Is In Correct");
                    return View(category);
                }

                category.Image = null;
            }

            if (await _context.Categories.AnyAsync(c=>c.IsDeleted == false && c.Name.ToLower() == category.Name.Trim().ToLower()))
            {
                ModelState.AddModelError("Name", "Already Exists");
                return View(category);
            }

            category.Name = category.Name.Trim();

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if(id == null) return BadRequest();

            Category category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted == false);

            if(category == null) return NotFound();
           
            ViewBag.Categories = await _context.Categories
               .Where(c => c.IsDeleted == false && c.IsMain == true)
               .ToListAsync();

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, Category category)
        {
            ViewBag.Categories = await _context.Categories
               .Where(c => c.IsDeleted == false && c.IsMain == true)
               .ToListAsync();

            if (id == null) return BadRequest();

            if(id != category.Id) return BadRequest();

            if(!ModelState.IsValid) return View(category);

            Category dbCategory = await _context.Categories
                .FirstOrDefaultAsync(c=>c.IsDeleted == false && c.Id == category.Id);

            if(dbCategory == null) return NotFound();

            if (await _context.Categories.AnyAsync(c => c.IsDeleted == false && c.Name.ToLower() == category.Name.Trim().ToLower() && c.Id != category.Id))
            {
                ModelState.AddModelError("Name", "Already Exists");
                return View(category);
            }

            if(dbCategory.IsMain != category.IsMain)
            {
                ModelState.AddModelError("IsMain", "Deyise Bilmez");
                return View(dbCategory);
            }

            if (dbCategory.IsMain)
            {
                if (category.File != null)
                {
                    if (category.File.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("File", "File Type Must Be .jpg Or .jpeg");
                        return View(category);
                    }

                    if ((category.File.Length / 1024) > 30)
                    {
                        ModelState.AddModelError("File", "File Type Must Be Maximum 30kb");
                        return View(category);
                    }

                    string fileName = DateTime.UtcNow.AddHours(4).ToString("yyyyMMddHHmmssfff") + category.File.FileName
                        .Substring(category.File.FileName.LastIndexOf('.'));

                    string filePath = Path.Combine(_env.WebRootPath, "assets", "images", dbCategory.Image);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    filePath = Path.Combine(_env.WebRootPath, "assets", "images",fileName);

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await category.File.CopyToAsync(fileStream);
                    }

                    dbCategory.Image = fileName;
                }

                dbCategory.ParentId = null;
            }
            else
            {
                if (category.ParentId == null)
                {
                    ModelState.AddModelError("ParentId", "Required");
                    return View(category);
                }

                if (!await _context.Categories.AnyAsync(c => c.IsDeleted == false && c.IsMain == true && c.Id == category.ParentId))
                {
                    ModelState.AddModelError("ParentId", "Is In Correct");
                    return View(category);
                }

                dbCategory.Image = null;
                dbCategory.ParentId = category.ParentId;
            }

            dbCategory.Name = category.Name.Trim();
            dbCategory.UpdatedAt = DateTime.Now;
            dbCategory.UpdatedBy = "User";
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null) return BadRequest();

            Category category = await _context.Categories
                .Include(c => c.Products.Where(p => p.IsDeleted == false))
                .Include(c => c.Children.Where(ch => ch.IsDeleted == false)).ThenInclude(c => c.Products.Where(p => p.IsDeleted == false))
                .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);

            if (category == null) return NotFound();

            if (category.Products != null && category.Products.Count() > 0)
            {
                return BadRequest();
            }

            if (category.Children != null && category.Children.Count() > 0)
            {
                foreach (Category child in category.Children)
                {
                    if (child.Products != null && child.Products.Count() > 0)
                    {
                        return BadRequest();
                    }
                }

                return BadRequest();
            }

            category.IsDeleted = true;
            category.DeletedAt = DateTime.Now;
            category.DeletedBy = "User";
            await _context.SaveChangesAsync();

            if (!string.IsNullOrWhiteSpace(category.Image))
            {
                string filePath = Path.Combine(_env.WebRootPath, "assets", "images", category.Image);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
