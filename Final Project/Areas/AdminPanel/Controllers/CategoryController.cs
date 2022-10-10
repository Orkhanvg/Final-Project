
using Final_Project.DAL;
using Final_Project.Extentions;
using Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Areas.AdminPanel.Controllers
{
    [Area("adminpanel")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            var allCategories = _context.Categories.ToList();
            var mainCategories = await _context.Categories.Where(c => c.ParentId == null).Where(c => c.IsDeleted != true).ToListAsync();
            ViewBag.Categories = new SelectList((mainCategories).ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            var mainCategories = await _context.Categories.Where(c => c.ParentId == null).Where(c => c.IsDeleted != true).ToListAsync();
            ViewBag.Categories = new SelectList((mainCategories).ToList(), "Id", "Name");
            Category dbCategory = await _context.Categories.FindAsync(category.Id);
            Category dbCategoryName = new Category();
            Category newCategory = new Category();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (category.Name == null)
            {
                ModelState.AddModelError("Name", "Category Name Cannot be Empty!");
                return View();
            }
            bool existCategoryName = _context.Categories.Where(c=>c.IsDeleted!=true).Any(c => c.Name.ToLower().Trim() == category.Name.ToLower().Trim());
            if (existCategoryName)
            {
                ModelState.AddModelError("Name", "The name of category is exist");
                return View();
            }

            if (category.ParentId == null && category.Image==null)
            {
                ModelState.AddModelError("Image", "Select Image");
                return View();
            }

            if (category.Image!=null)
            {

                if (!category.Image.IsImage())
                {
                    ModelState.AddModelError("Image", "Only Image Files");
                    return View();
                }
                if (category.Image.ValidSize(1000))
                {
                    ModelState.AddModelError("Image", "Size is higher max 1mb");
                    return View();
                }
                newCategory.ImageUrl = category.Image.SaveImage(_env, "assets/images");
            }
            newCategory.Name = category.Name;
            newCategory.ParentId = category.ParentId;
            newCategory.CreatedAt = System.DateTime.Now;


            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        //[AllowAnonymous]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Category dbCategory = await _context.Categories.FindAsync(id);
            if (dbCategory == null) return NotFound();
            return View(dbCategory);
        }

        public async Task<IActionResult> CreateSubCategory()
        {
            var allCategories = _context.Categories.ToList();
            var mainCategories = await _context.Categories.Where(c => c.ParentId == null).Where(c => c.IsDeleted != true).ToListAsync();
            ViewBag.Categories = new SelectList((mainCategories).ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubCategory(Category category)
        {
            var allCategories = _context.Categories.ToList();
            var mainCategories = await _context.Categories.Where(c => c.ParentId == null).Where(c=>c.IsDeleted!=true).ToListAsync();
            ViewBag.Categories = new SelectList((mainCategories).ToList(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (category.Name == null)
            {
                ModelState.AddModelError("Name", "Category Name Cannot be Empty!");
                return View();
            }
             bool existCategoryName = _context.Categories.Where(c=>c.IsDeleted != true).Any(c => c.Name.ToLower().Trim() == category.Name.ToLower().Trim());
            if (existCategoryName)
            {
                ModelState.AddModelError("Name", "The name of category is exist");
                return View();
            }
            Category newCategory = new Category()
            {
                Name = category.Name,
                ParentId = category.ParentId,
                CreatedAt = System.DateTime.Now,
            };
            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
            public async Task<IActionResult> Update(int? id)
            {
            var mainCategories = await _context.Categories.Where(c => c.ParentId == null).ToListAsync();
            ViewBag.Categories = new SelectList((mainCategories).ToList(), "Id", "Name");
            if (id == null) return NotFound();
            Category dbCategory = await _context.Categories.FindAsync(id);
            if (dbCategory == null) return NotFound();

            return View(dbCategory);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Category category)
        {
          
            if (!ModelState.IsValid)
            {
                return View();
            }

            Category dbCategory = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (dbCategory == null)
            {
                return View();
            }

            Category dbCategoryName = _context.Categories.FirstOrDefault(c => c.Name.ToLower().Trim() == category.Name.ToLower().Trim());
            string path = "";
            if (category.Image == null)
            {
                dbCategory.ImageUrl = dbCategory.ImageUrl;
            }
            else
            {
                if (!category.Image.IsImage())
                {
                    ModelState.AddModelError("Photo", "Only Image Files");
                    return View();
                }

                if (category.Image.ValidSize(1000))
                {
                    ModelState.AddModelError("Photo", "Size is higher max 1mb");
                    return View();
                }
                string oldImg = dbCategory.ImageUrl;
                if (oldImg != null)
                {
                    path = Path.Combine(_env.WebRootPath, "assets/images", oldImg);
                }
                if (path != null)
                {
                    Helpers.Helper.DeleteImage(path);
                }
                else return NotFound();

                dbCategory.ImageUrl = category.Image.SaveImage(_env, "assets/images");
            }
            
            if (dbCategoryName != null)
            {
                if (dbCategory.Name != dbCategoryName.Name)
                {
                    ModelState.AddModelError("Name", "This Name already was taken");
                    return View();
                }
            }
            dbCategory.ParentId = category.ParentId;
            dbCategory.Name = category.Name;
            dbCategory.UptadetAt = System.DateTime.Now;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Category dbCategory = await _context.Categories.FindAsync(id);
            if (dbCategory == null) return NotFound();
            dbCategory.DeletedAt=System.DateTime.Now;
            dbCategory.IsDeleted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }

}