using Final_Project.DAL;
using Final_Project.Models;
using Final_Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class OrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;

        public OrderController(UserManager<AppUser> userManager, RoleManager<IdentityRole> rolemanager, SignInManager<AppUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _rolemanager = rolemanager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<AppUser> users =await _userManager.Users.Include(o => o.Orders).ThenInclude(i => i.OrderItems).ToListAsync();
            OrderVM orderVM = new OrderVM();
            List<Order> orders = _context.Orders.Include(u=>u.AppUser).Include(o=>o.OrderItems).OrderByDescending(t=>t.SaledAt).ToList();
            orderVM.Orders = orders;
            orderVM.AppUsers = users;
            return View(orderVM);
        }
    }
}
