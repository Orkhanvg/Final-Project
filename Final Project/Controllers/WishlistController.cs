using Final_Project.DAL;
using Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    public class WishlistController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public WishlistController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<WishList> wishLists = _context.WishLists.Where(x => x.UserId == currentUserId).Include(p => p.Product).ThenInclude(x => x.ProductImages).ToList();

            return View(wishLists);
        }

        [HttpPost]
        public ActionResult Additem(int id)
        {

            
            if (!User.Identity.IsAuthenticated) return BadRequest();

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (currentUserId == null) return NotFound();

            Product dbProcduct = _context.Products
                    .Include(p => p.ProductImages)
                    .Include(p => p.Brand)
                    .Include(p => p.Category)
                    .FirstOrDefault(p => p.Id == id);

            if (dbProcduct == null) return NotFound();


            IQueryable<WishList> wishList = _context.WishLists.Where(w => w.UserId == currentUserId && w.ProductId == id);

            if (wishList.Count() == 0)
            {
                WishList newWishList = new WishList();
                newWishList.Product = dbProcduct;
                newWishList.UserId = currentUserId;

                _context.WishLists.Add(newWishList);
                _context.SaveChanges();
                ViewBag.WishCount = _context.WishLists.Count();
            }


            return RedirectToAction("index", "home");
        }

        public ActionResult Remove(int id)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var listwish = _context.WishLists.Where(x => x.UserId == currentUserId).ToList();

            var wish = listwish.Find(x => x.ProductId == id);

            _context.WishLists.Remove(wish);
            _context.SaveChanges();


            return RedirectToAction("index", "wishlist");
        }

    }
}

