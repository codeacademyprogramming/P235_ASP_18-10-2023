using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P235AllupDb.DataAccessLayer;
using P235AllupDb.Models;
using P235AllupDb.ViewModels;

namespace P235AllupDb.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles ="SuperAdmin,Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        //[AllowAnonymous]
        public IActionResult Index(int currentPage = 1)
        {
            IQueryable<Product> products = _context.Products
                .Include(p=>p.Category)
                .Include(p=>p.Brand)
                .Include(p=>p.ProductTags.Where(emrah=>emrah.IsDeleted == false)).ThenInclude(pt=>pt.Tag)
                .Where(p=>p.IsDeleted == false)
                .OrderByDescending(c=>c.Id);

            return View(PageNatedList<Product>.Create(products,currentPage,5,10));
        }

        [HttpGet]
        //[Authorize(Roles ="SuperAdmin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Brands = await _context.Brands.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(c => c.IsDeleted == false).ToListAsync();

            return View();
        }

        [HttpPost]
        //[Authorize(Roles = "SuperAdmin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Brands = await _context.Brands.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(c => c.IsDeleted == false).ToListAsync();

            if(!ModelState.IsValid) return View(product);

            if (product.CategoryId == null || !await _context.Categories.AnyAsync(c=>c.IsDeleted == false && c.Id == product.CategoryId))
            {
                ModelState.AddModelError("CategoryId", $"Category Id = {product.CategoryId} Is InCorrect");
                return View(product);
            }

            if (product.BrandId != null && !await _context.Brands.AnyAsync(c => c.IsDeleted == false && c.Id ==product.BrandId))
            {
                ModelState.AddModelError("BrandId", $"Brand Id = {product.BrandId} Is InCorrect");
                return View(product);
            }

            List<ProductTag> productTags = new List<ProductTag>();

            if (product.TagIds != null && product.TagIds.Count() > 0)
            {
                foreach (int tagId in product.TagIds)
                {
                    if (!await _context.Tags.AnyAsync(t=>t.IsDeleted == false && t.Id == tagId))
                    {
                        ModelState.AddModelError("TagIds", $"Tag Id = {tagId} Is InCorrect");
                        return View(product);
                    }

                    ProductTag productTag = new ProductTag 
                    {
                        TagId = tagId,
                    }; 
                    
                    productTags.Add(productTag);
                }
            }

            product.ProductTags = productTags;

            if (product.Files == null || product.Files.Count() <= 0 )
            {
                ModelState.AddModelError("Files", $"Minimum 1 Fayl Olmalidi");
                return View(product);
            }

            if (product.Files.Count() > 10)
            {
                ModelState.AddModelError("Files", $"Maksimum 10 Fayl Olmalidi");
                return View(product);
            }

            foreach (IFormFile file in product.Files)
            {
                if (!file.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Files", "File Type Must Be .jpg Or .jpeg");
                    return View(product);
                }

                if ((file.Length / 1024) > 300)
                {
                    ModelState.AddModelError("Files", "File Type Must Be Maximum 300kb");
                    return View(product);
                }
            }

            List<ProductImage> productImages = new List<ProductImage>();

            foreach (IFormFile file in product.Files)
            {
                string fileName = DateTime.UtcNow.AddHours(4).ToString("yyyyMMddHHmmssfff") + file.FileName
                    .Substring(file.FileName.LastIndexOf('.'));

                string filePath = Path.Combine(_env.WebRootPath, "assets", "images", "product", fileName);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                ProductImage productImage = new ProductImage 
                {
                    Image = fileName
                }; 

                productImages.Add(productImage);
            }

            product.ProductImages = productImages;  

            if (product.MainFile != null)
            {
                if (!product.MainFile.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("MainFile", "Main File Type Must Be .jpg Or .jpeg");
                    return View(product);
                }

                if ((product.MainFile.Length / 1024) > 300)
                {
                    ModelState.AddModelError("MainFile", "Main File Type Must Be Maximum 300kb");
                    return View(product);
                }

                string fileName = DateTime.UtcNow.AddHours(4).ToString("yyyyMMddHHmmssfff") + product.MainFile.FileName
                    .Substring(product.MainFile.FileName.LastIndexOf('.'));

                string filePath = Path.Combine(_env.WebRootPath, "assets", "images", "product", fileName);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await product.MainFile.CopyToAsync(fileStream);
                }

                product.MainImage = fileName;
            }
            else
            {
                ModelState.AddModelError("MainFile", $"Main File Required");
                return View(product);
            }

            if (product.HoverFile != null)
            {
                if (!product.HoverFile.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("HoverFile", "Hover File Type Must Be .jpg Or .jpeg");
                    return View(product);
                }

                if ((product.HoverFile.Length / 1024) > 300)
                {
                    ModelState.AddModelError("HoverFile", "Hover File Type Must Be Maximum 300kb");
                    return View(product);
                }

                string fileName = DateTime.UtcNow.AddHours(4).ToString("yyyyMMddHHmmssfff") + product.HoverFile.FileName
                    .Substring(product.HoverFile.FileName.LastIndexOf('.'));

                string filePath = Path.Combine(_env.WebRootPath, "assets", "images", "product", fileName);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await product.HoverFile.CopyToAsync(fileStream);
                }

                product.HoverImage = fileName;
            }
            else
            {
                ModelState.AddModelError("HoverFile", $"HoverFile Required");
                return View(product);
            }

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == product.CategoryId);
            Brand brand = await _context.Brands.FirstOrDefaultAsync(c => c.Id == product.BrandId);

            string seria = (category.Name.Substring(0, 2) + brand.Name.Substring(0, 2)).ToLower();

            Product prod = await _context.Products
                .Where(c => c.Seria.ToLower() == seria)
                .OrderByDescending(c=>c.Number)
                .FirstOrDefaultAsync();

            int? number = prod != null ? prod.Number+1 : 1;

            product.Seria = seria;
            product.Number = number;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        //[Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Update(int? id)
        {
            if(id == null) return BadRequest();

            Product? product = await _context.Products
                .Include(c => c.ProductImages.Where(pi=>pi.IsDeleted == false))
                //.Include(c=>c.ProductTags.Where(pt=>pt.IsDeleted == false))
                .FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted == false);

            if(product == null) return NotFound();

            //List<int> tagIds = new List<int>();

            //if (product.ProductTags != null && product.ProductTags.Count > 0)
            //{
            //    foreach (ProductTag productTag in product.ProductTags)
            //    {
            //        tagIds.Add(productTag.TagId);
            //    }
            //}

            product.TagIds = await _context.ProductTags
                .Where(pt=>pt.ProductId == product.Id && pt.IsDeleted == false)
                .Select(x => x.TagId).ToListAsync();

            ViewBag.Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Brands = await _context.Brands.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(c => c.IsDeleted == false).ToListAsync();

            return View(product);
        }

        [HttpPost]
        //[Authorize(Roles = "SuperAdmin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Product product)
        {
            ViewBag.Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Brands = await _context.Brands.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(c => c.IsDeleted == false).ToListAsync();

            if(id == null) return BadRequest();

            if (product.Id != id) return BadRequest();

            Product? dbProduct = await _context.Products
            .Include(c => c.ProductImages.Where(pi => pi.IsDeleted == false))
            .Include(c => c.ProductTags.Where(pt => pt.IsDeleted == false))
            .FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted == false);

            if (dbProduct == null) return NotFound();

            dbProduct.TagIds = product.TagIds;

            if (!ModelState.IsValid) return View(dbProduct);

            int canUpload = 10 - dbProduct.ProductImages.Count;

            if (product.Files != null && product.Files.Count() > canUpload)
            {
                ModelState.AddModelError("Files", $"Maksimum {canUpload} qeder Fayl Elave Ede Bilersiz");
                return View(dbProduct);
            }

            if (product.CategoryId == null || !await _context.Categories.AnyAsync(c=>c.IsDeleted == false && c.Id == product.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "InCorrect");
                return View(dbProduct);
            }

            if (product.BrandId != null && !await _context.Brands.AnyAsync(c => c.IsDeleted == false && c.Id == product.BrandId))
            {
                ModelState.AddModelError("BrandId", "InCorrect");
                return View(dbProduct);
            }

            if (dbProduct.ProductTags != null && dbProduct.ProductTags.Count > 0)
            {
                foreach (ProductTag productTag in dbProduct.ProductTags)
                {
                    productTag.IsDeleted = true;
                    productTag.DeletedAt = DateTime.Now;
                    productTag.DeletedBy = "User";
                }
            }

            List<ProductTag> productTags = new List<ProductTag>();

            if (product.TagIds != null && product.TagIds.Count() > 0)
            {
                foreach (int tagId in product.TagIds)
                {
                    if (!await _context.Tags.AnyAsync(t => t.IsDeleted == false && t.Id == tagId))
                    {
                        ModelState.AddModelError("TagIds", $"Tag Id = {tagId} Is InCorrect");
                        return View(dbProduct);
                    }

                    ProductTag productTag = new ProductTag
                    {
                        TagId = tagId,
                    };

                    productTags.Add(productTag);
                }
            }

            dbProduct.ProductTags.AddRange(productTags);

            if (product.MainFile != null)
            {
                if (!product.MainFile.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("MainFile", "Main File Type Must Be .jpg Or .jpeg");
                    return View(dbProduct);
                }

                if ((product.MainFile.Length / 1024) > 300)
                {
                    ModelState.AddModelError("MainFile", "Main File Type Must Be Maximum 300kb");
                    return View(dbProduct);
                }

                string filePath = Path.Combine(_env.WebRootPath, "assets", "images", "product", dbProduct.MainImage);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                string fileName = DateTime.UtcNow.AddHours(4).ToString("yyyyMMddHHmmssfff") + product.MainFile.FileName
                    .Substring(product.MainFile.FileName.LastIndexOf('.'));

                filePath = Path.Combine(_env.WebRootPath, "assets", "images", "product", fileName);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await product.MainFile.CopyToAsync(fileStream);
                }

                dbProduct.MainImage = fileName;
            }

            if (product.HoverFile != null)
            {
                if (!product.HoverFile.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("HoverFile", "Hover File Type Must Be .jpg Or .jpeg");
                    return View(dbProduct);
                }

                if ((product.HoverFile.Length / 1024) > 300)
                {
                    ModelState.AddModelError("HoverFile", "Hover File Type Must Be Maximum 300kb");
                    return View(dbProduct);
                }

                string filePath = Path.Combine(_env.WebRootPath, "assets", "images", "product", dbProduct.HoverImage);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                string fileName = DateTime.UtcNow.AddHours(4).ToString("yyyyMMddHHmmssfff") + product.HoverFile.FileName
                    .Substring(product.HoverFile.FileName.LastIndexOf('.'));

                filePath = Path.Combine(_env.WebRootPath, "assets", "images", "product", fileName);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await product.HoverFile.CopyToAsync(fileStream);
                }

                dbProduct.HoverImage = fileName;
            }

            if (product.Files != null)
            {
                foreach (IFormFile file in product.Files)
                {
                    if (!file.ContentType.Contains("image/"))
                    {
                        ModelState.AddModelError("Files", "File Type Must Be .jpg Or .jpeg");
                        return View(dbProduct);
                    }

                    if ((file.Length / 1024) > 300)
                    {
                        ModelState.AddModelError("Files", "File Type Must Be Maximum 300kb");
                        return View(dbProduct);
                    }
                }

                List<ProductImage> productImages = new List<ProductImage>();

                foreach (IFormFile file in product.Files)
                {
                    string fileName = DateTime.UtcNow.AddHours(4).ToString("yyyyMMddHHmmssfff") + file.FileName
                        .Substring(file.FileName.LastIndexOf('.'));

                    string filePath = Path.Combine(_env.WebRootPath, "assets", "images", "product", fileName);

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    ProductImage productImage = new ProductImage
                    {
                        Image = fileName
                    };

                    productImages.Add(productImage);
                }

                dbProduct.ProductImages.AddRange(productImages);
            }

            dbProduct.Title = product.Title.Trim();
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.BrandId = product.BrandId;
            dbProduct.Price = product.Price;
            dbProduct.DiscountedPrice = product.DiscountedPrice;
            dbProduct.Description = product.Description;
            dbProduct.ExTag = product.ExTag;
            dbProduct.Count = product.Count;
            dbProduct.IsBestSeller = product.IsBestSeller;
            dbProduct.IsFeatured = product.IsFeatured;
            dbProduct.IsNewArrival = product.IsNewArrival;
            dbProduct.SmallDescription = product.SmallDescription;

            dbProduct.UpdatedBy = "User";
            dbProduct.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteImage(int? id, int? imageId)
        {
            if(id == null) return BadRequest();

            if(imageId == null) return BadRequest();

            Product? product = await _context.Products
                .Include(p=>p.ProductImages.Where(pi=>pi.IsDeleted == false))
                .FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted == false);

            if(product == null) return NotFound();

            if(!product.ProductImages.Any(pi=>pi.Id == imageId)) return NotFound();

            if(product.ProductImages.Count <= 1) return BadRequest();

            product.ProductImages.FirstOrDefault(pi => pi.Id == imageId).IsDeleted = true;
            product.ProductImages.FirstOrDefault(pi => pi.Id == imageId).DeletedAt = DateTime.Now;
            product.ProductImages.FirstOrDefault(pi => pi.Id == imageId).DeletedBy = "User";

            string fileName = product.ProductImages.FirstOrDefault(pi => pi.Id == imageId).Image;
            await _context.SaveChangesAsync();

            string filePath = Path.Combine(_env.WebRootPath, "assets", "images", "product", fileName);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            return PartialView("_DeleteImagePartial",product.ProductImages.Where(p=>p.IsDeleted == false).ToList());
        }
    }
}
