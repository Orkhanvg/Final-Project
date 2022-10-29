using Final_Project.DAL;
using Final_Project.Models;
using Final_Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    public class OrderController : Controller
    {

        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public OrderController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Sale(Order order)
        {
            double total = 0;
            if (User.Identity.IsAuthenticated)
            {

                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                List<Product> dbProducts = _context.Products.Include(p => p.ProductImages).ToList();
                List<BasketItem> basketItems = _context.BasketItems.Include(b => b.Product).Where(b => b.UserId == user.Id).ToList();

                Order newOrder = new Order();
                newOrder.AppUserId = user.Id;
                newOrder.Email = user.Email;
                newOrder.Address = order.Address;
                newOrder.City = order.City;
                newOrder.Country = order.Country;
                newOrder.Phone = order.Phone;
                newOrder.FirstName = order.FirstName;
                newOrder.LastName = order.LastName;
              
                newOrder.OrderStatus = OrderStatus.Shipped;

                _context.Orders.Add(newOrder);
                _context.SaveChanges();

                foreach (var item in basketItems)
                {
                    OrderItem orderItem = new OrderItem();
                    orderItem.ProductId = item.ProductId;
                    orderItem.Product = item.Product;
                    orderItem.Count = item.Count;
                    //orderItem.Total = total;
                    orderItem.OrderId = order.Id;
                    //orderItem.Orders = order;

                    _context.Products.Find(item.ProductId).StockCount -= item.Count;
                    _context.OrderItems.Add(orderItem);
                    _context.BasketItems.Remove(item);
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "order");
        }
    }
}
