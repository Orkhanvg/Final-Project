﻿using Final_Project.DAL;
using Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
   
        public class SubscribeController : Controller
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly RoleManager<IdentityRole> _rolemanager;
            private readonly SignInManager<AppUser> _signInManager;
            private readonly AppDbContext _context;

            public SubscribeController(UserManager<AppUser> userManager, RoleManager<IdentityRole> rolemanager, SignInManager<AppUser> signInManager, AppDbContext context)
            {
                _userManager = userManager;
                _rolemanager = rolemanager;
                _signInManager = signInManager;
                _context = context;
            }
            [HttpPost]
            public async Task<IActionResult> Form([FromForm] Subscriber subs)
            {
                Subscriber subscribe = new Subscriber();
                List<Subscriber> subscribers = await  _context.Subscribers.ToListAsync();
                if (string.IsNullOrEmpty(subs.Email))
                {
                    return Ok(" Do not leave it empty");
                }
                else
                {
                    foreach (var item in subscribers)
                    {
                        if (item.Email == subs.Email)
                        {
                            return Ok("This account is already available in our database");
                        }
                        else
                        {
                            subscribe.Email = subs.Email;

                            _context.Subscribers.Add(subscribe);
                            _context.SaveChanges();
                        }
                        break;
                    }
                }

                return Ok();
            }
        }
    }

