using Final_Project.DAL;
using Final_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    public class HomeController : Controller
    {
        public readonly AppDbContext _context;

        public HomeController (AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Include(p => p.ProductImages).ToListAsync();
            HomeVM homeVM = new HomeVM();
            homeVM.SliderContents = await _context.SliderContents.Include(s => s.Slider).ToListAsync();
            homeVM.Banners = await _context.Banners.ToListAsync();
            homeVM.Categories = await _context.Categories.Include(c => c.Children).ToListAsync();
            homeVM.Brands = await _context.Brands.ToListAsync();
            homeVM.Products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.ProductImages)
                .ToListAsync();
            homeVM.ProductImages = await _context.ProductImages.Include(i => i.Product).ToListAsync();

            var newProduct = products.Where(p => p.NewArrival).ToList();    /*editable*/
            var isFeatured = products.Where(p => p.IsFeatured).ToList();    /*editable*/
            var bestSeller = products.Where(p => p.BestSeller).ToList();    /*editable*/

            ViewBag.newProduct = newProduct;
            ViewBag.isFeatured = isFeatured;
            ViewBag.bestSeller = bestSeller;
            return View(homeVM);
        }


        public IActionResult Shop(int page = 1, int take = 12)
        {

            List<Product> product = _context.Products.Where(p => p.IsDeleted != true)
                .Include(p => p.Category).Where(c => c.IsDeleted != true)
                .Include(pi => pi.ProductImages).Skip((page - 1) * take).Take(take).ToList();
            PaginationVM<Product> paginationVM = new PaginationVM<Product>(product, PageCount(take), page);

            return View(paginationVM);
        }

        private int PageCount(int take)
        {
            List<Product> products = _context.Products.Where(p => p.IsDeleted != true).ToList();
            return (int)Math.Ceiling((decimal)products.Count() / take);
        }


        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Product product = await _context.Products
                .Include(b => b.Brand)
                .Include(i => i.ProductImages)
                .Include(t => t.ProductTags).ThenInclude(t => t.Tag)
                .FirstOrDefaultAsync(p => p.Id == id);
            ViewBag.ProdLentgh = product.Desc.Count();
            HomeVM homeVM = new HomeVM();
            homeVM.ProductDetail = product;
            homeVM.Products = _context.Products.Where(p => p.IsDeleted != true).Include(i => i.ProductImages).ToList();
            return View(homeVM);
        }
    }
}
