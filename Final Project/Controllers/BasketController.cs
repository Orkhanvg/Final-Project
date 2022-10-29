
using Final_Project.DAL;
using Final_Project.Models;
using Final_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{ 
    [Authorize]
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BasketController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        string userName = "";

        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> AddItem(int? id)
        {
            double price = 0;
            double count = 0;
            ViewBag.IsLogin = User.Identity.IsAuthenticated;
            userName = User.Identity.Name;
            if (id == null) return NotFound();

            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();

            List<BasketVM> products;

            if (Request.Cookies[$"{userName}basket"] == null)
            {
                products = new List<BasketVM>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>((Request.Cookies[$"{userName}basket"]));
            }
            BasketVM existProduct = products.Find(p => p.Id == id);
            if (existProduct == null)
            {
                BasketVM basketVM = new BasketVM
                {
                    Id = dbProduct.Id,
                    ProductCount = 1,
                };
                if (dbProduct.DiscountPercent > 0)
                {
                    basketVM.Price = dbProduct.DiscountPrice;

                }
                else
                {
                    basketVM.Price = dbProduct.Price;

                }
                products.Add(basketVM);
            }
            else
            {
                existProduct.ProductCount++;
            }

            Response.Cookies.Append($"{userName}basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });



            foreach (var product in products)
            {
                price += product.Price * product.ProductCount;
                count += product.ProductCount;
            }
            var obj = new
            {
                Price = price,
                Count = count,
            };


            return Ok(obj);
        }
        public IActionResult ShowItem()
        {
            ViewBag.brand = _context.Brands.Where(b => b.IsDeleted != true).ToList();
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }
            string basket = Request.Cookies[$"{userName}basket"];
            List<BasketVM> products;
            if (basket != null)
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                foreach (var item in products)
                {
                    Product dbProduct = _context.Products.Include(c => c.Category)
                    .Include(i => i.ProductImages)
                    .FirstOrDefault(p => p.Id == item.Id);
                    if (dbProduct.DiscountPercent > 0)
                    {
                        item.Price = dbProduct.DiscountPrice;
                    }
                    else
                    {
                        item.Price = dbProduct.Price;
                    }
                    item.Name = dbProduct.Name;
                    item.Category = dbProduct.Category.Name;
                    item.Desc = dbProduct.Desc;
                    foreach (var prod in dbProduct.ProductImages)
                    {
                        item.ImageUrl = prod.ImageUrl;
                    }
                }
            }
            else
            {
                products = new List<BasketVM>();
            }
            return View(products);
        }




        public IActionResult minusitem(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }
            List<BasketVM> products;
            string basket = Request.Cookies[$"{userName}basket"];
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM existProduct = products.Find(p => p.Id == id);
            if (existProduct.ProductCount > 1)
            {
                existProduct.ProductCount--;
            }
            else
            {
                products.Remove(existProduct);
            }
            Response.Cookies.Append($"{userName}basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });

            int totalCount = 0;
            double totalPrice = 0;
            foreach (var item in products)
            {
                totalPrice += item.ProductCount * item.Price;
                totalCount += item.ProductCount;
            }
            var obj = new
            {
                price = existProduct.Price,
                productCount = existProduct.ProductCount,
                TotalCount = totalCount,
                TotalPrice = totalPrice
            };
            return Ok(obj);
        }




       
        public IActionResult plusitem(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            List<BasketVM> products;
            string basket = Request.Cookies[$"{userName}basket"];
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM existProduct = products.Find(p => p.Id == id);
            if (product.StockCount <= existProduct.ProductCount)
            {
                return Ok($"{product.Name}-dan bazada cemisi {product.StockCount} eded var");
            }
            else
            {
                existProduct.ProductCount++;
            }
            Response.Cookies.Append($"{userName}basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });
            //return RedirectToAction("showitem", $"{userName}basket");
            int totalCount = 0;
            double totalPrice = 0;
            foreach (var item in products)
            {
                totalPrice += item.ProductCount * item.Price;
                totalCount += item.ProductCount;
            }
            var obj = new
            {
                price = existProduct.Price,
                productCount = existProduct.ProductCount,
                TotalCount = totalCount,
                TotalPrice = totalPrice
            };
            return Ok(obj);

        }
        public IActionResult removeItem(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }
            List<BasketVM> products;
            string basket = Request.Cookies[$"{userName}basket"];
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

            BasketVM existProduct = products.Find(p => p.Id == id);
            products.Remove(existProduct);
            Response.Cookies.Append($"{userName}basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });
            return RedirectToAction("showitem", "basket");
        }


        [HttpPost]
        public async Task<IActionResult> Order(Order newOrder)
        {
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;

                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order();
                order.FirstName = newOrder.FirstName;
                order.LastName = newOrder.LastName;
                order.City = newOrder.City;
                order.Country = newOrder.Country;
                order.Email = newOrder.Email;
                order.Phone = newOrder.Phone;
                order.ZipCode = newOrder.ZipCode;
                order.Address = newOrder.Address;
                order.SaledAt = DateTime.Now;
                order.AppUserId = user.Id;
                order.OrderStatus = OrderStatus.Pending;



                List<BasketVM> basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies[$"{userName}basket"]);
                ViewBag.Products = basketProducts;
                List<OrderItem> orderItems = new List<OrderItem>();
                double total = 0;
                foreach (var basketProduct in basketProducts)
                {
                    Product dbProduct = await _context.Products.FindAsync(basketProduct.Id);
                    if (basketProduct.ProductCount > dbProduct.StockCount)
                    {
                        TempData["fail"] = "Satış uğursuzdur..";
                        return RedirectToAction("ShowItem");
                    }
                    OrderItem orderItem = new OrderItem();
                    orderItem.ProductId = dbProduct.Id;
                    orderItem.Count = basketProduct.ProductCount;
                    orderItem.OrderId = order.Id;


                    orderItem.TotalPrice = (int)dbProduct.Price;
                    orderItems.Add(orderItem);
                    total += basketProduct.ProductCount * dbProduct.Price;

                    dbProduct.StockCount = dbProduct.StockCount - basketProduct.ProductCount;
                    dbProduct.SaleCount += basketProduct.ProductCount;
                    if (dbProduct.SaleCount >= 50)
                    {
                        dbProduct.BestSeller = true;
                    }
                }
                order.OrderItems = orderItems;
                order.TotalPrice = total;

                await _context.AddAsync(order);
                await _context.SaveChangesAsync();

                TempData["success"] = "Satış uğurla başa çatdı..";
                return RedirectToAction("ShowItem");
            }
            else
            {
                return RedirectToAction("login", "account");
            }

        }

        public IActionResult Checkout()
        {
            ViewBag.brand = _context.Brands.Where(b => b.IsDeleted != true).ToList();
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }

            string basket = Request.Cookies[$"{userName}basket"];
            List<BasketVM> products;
            if (basket != null)
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                if (products != null)
                {
                    ViewBag.Products = products;
                }
                foreach (var item in products)
                {
                    Product dbProduct = _context.Products
                    .FirstOrDefault(p => p.Id == item.Id);
                    if (dbProduct.DiscountPercent > 0)
                    {
                        item.Price = dbProduct.DiscountPrice;
                    }
                    else
                    {
                        item.Price = dbProduct.Price;
                    }
                    item.Name = dbProduct.Name;
                }
            }
            else
            {
                products = new List<BasketVM>();
            }

            return View();

            
        }
    }
}

