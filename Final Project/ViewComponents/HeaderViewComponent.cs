﻿using Final_Project.DAL;
using Final_Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategory category;

        public HeaderViewComponent(AppDbContext context, ICategory category, UserManager<AppUser> userManager)
        {
            _context = context;
            _category = category;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if(User != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                   
                    AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                    ViewBag.User = user.FullName;
                }
                else
                {
                    return View();
                }

                ViewBag.BasketCount = 0;
                ViewBag.TotalPrice = 0;
                double totalPrice = 0;
                double total = 0;
                int totalCount = 0;
                string userName = "";
                if (User.Identity.IsAuthenticated)
                {
                    userName = User.Identity.Name;
                }
                string basket = Request.Cookies[$"{userName}basket"];
                if (basket != null)
                {
                    List<BasketVM> products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                    //ViewBag.BasketCount =products.Count();
                    foreach (var item in products)
                    {
                        totalPrice += item.Price * item.ProductCount;
                        totalCount += item.ProductCount;
                        total += totalPrice;
                    }
                }
                ViewBag.Categories = _category.Category();
                ViewBag.BasketCount = totalCount;
                ViewBag.TotalPrice = totalPrice;
                Bio bio = _context.Bios.FirstOrDefault();



            }
        }
            
    }
}
