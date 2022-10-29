﻿using Final_Project.DAL;
using Final_Project.Models;
using Final_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private IConfiguration _config { get; }
        private readonly UserManager<AppUser> _usermanager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser>? _signInManager;
        public BlogController(AppDbContext context, IWebHostEnvironment env, IConfiguration config, UserManager<AppUser> usermanager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser>? signInManager)
        {
            _context = context;
            _env = env;
            _config = config;
            _usermanager = usermanager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }


        public async Task<IActionResult> Index()
        {
            List<Blog>? blogs = _context?.Blogs?.Where(b => !b.IsDeleted).ToList();
            foreach (var item in blogs)
            {
                item.CommentCount = _context?.BlogComments?.Where(bc => bc.BlogId == item.Id && !bc.IsDeleted).ToList().Count;
                _context.SaveChanges();
            }
            UserBlogDetailVM? blog = new UserBlogDetailVM
            {
                Blogs = _context?.Blogs?.Where(b => !b.IsDeleted)?.OrderByDescending(b => b.Id)?.Include(b => b.BlogSubjects).ThenInclude(bs => bs.Subjects).ToList(),
            };
            if (User.Identity.IsAuthenticated)
            {
                AppUser AppUser = await _usermanager.FindByNameAsync(User.Identity.Name);
                var userroles = await _usermanager.GetRolesAsync(AppUser);
                foreach (var item in userroles)
                {
                    if (item.ToLower() == "ban" || userroles == null)
                    {
                        await _signInManager.SignOutAsync();
                        return RedirectToAction("error", "home");
                    }
                }
            }
            return View(blog);

        }



        public async Task<IActionResult> Detail(int? id)
        {
            Blog? dbBlog = await _context?.Blogs?
                .Include(b => b.BlogSubjects)
                .ThenInclude(bs => bs.Subjects)
                .Include(b => b.AppUser)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (dbBlog.IsDeleted || dbBlog == null)
            {
                return RedirectToAction("error", "home");
            }
            AppUser Editor = await _usermanager.FindByIdAsync(dbBlog.AppUserId);
            if (User.Identity.IsAuthenticated)
            {
                if (User.Identity.IsAuthenticated)
                {
                    AppUser AppUser = await _usermanager.FindByNameAsync(User.Identity.Name);
                    var userroles = await _usermanager.GetRolesAsync(AppUser);
                    foreach (var item in userroles)
                    {
                        if (item.ToLower() == "ban" || userroles == null)
                        {
                            await _signInManager.SignOutAsync();
                            return RedirectToAction("error", "home");
                        }
                    }
                }
                AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                ViewBag.AppUserId = user.Id;
                int RightCounter = 0;
                var roles = await _usermanager.GetRolesAsync(user);
                foreach (var item in roles)
                {
                    if (item.ToLower().Contains("admin") || item.ToLower().Contains("editor") || item.ToLower().Contains("moderator"))
                    {
                        RightCounter++;
                    }
                }
                ViewBag.RightCounter = RightCounter;
            }
            dbBlog.ViewCount++;
            dbBlog.CommentCount = _context?.BlogComments?.Where(b => b.BlogId == dbBlog.Id && !b.IsDeleted).ToList().Count;
            List<BlogComment>? Comments = _context?.BlogComments?
                .Include(b => b.User)
                .Where(c => c.BlogId == dbBlog.Id && !c.IsDeleted)
                .OrderByDescending(b => b.Id)
                .Take(10)
                .ToList();
            BlogVM? blog = new BlogVM
            {
                Blog = dbBlog,
                Comments = Comments,
                User = Editor
            };
            await _context.SaveChangesAsync();
            return View(blog);
        }



        public async Task<IActionResult> LoadComments(int skip, int? BlogId)
        {

            List<BlogComment>? comments = _context?.BlogComments?
                .Include(b => b.User)
                .Where(bc => bc.BlogId == BlogId && !bc.IsDeleted)
                .OrderByDescending(b => b.Id).Skip(skip).Take(2).ToList();
            CommentsVM commentsVM = new CommentsVM
            {
                BlogComments = comments
            };
            if (User.Identity.IsAuthenticated)
            {
                AppUser AppUser = await _usermanager.FindByNameAsync(User.Identity.Name);
                var userroles = await _usermanager.GetRolesAsync(AppUser);
                foreach (var item in userroles)
                {
                    if (item.ToLower() == "ban" || userroles == null)
                    {
                        await _signInManager.SignOutAsync();
                        return RedirectToAction("error", "home");
                    }
                }
            }
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                ViewBag.AppUserId = user.Id;
                int RightCounter = 0;
                var roles = await _usermanager.GetRolesAsync(user);
                //if requester is an admin or editor, he will be able to delete comment
                foreach (var item in roles)
                {
                    if (item.ToLower().Contains("admin") || item.ToLower().Contains("editor") || item.ToLower().Contains("moderator"))
                    {
                        RightCounter++;
                    }
                }

                //if requester is not an admin but a user and finds any of his comment among those,
                //he will be able to delete his own comment
                commentsVM.UserId = user.Id;


                commentsVM.RightCounter = RightCounter;
            }
            return PartialView("_Comments", commentsVM);
        }




        [HttpPost]
        public async Task<IActionResult> PostComment(int id, string comment, string? author)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser AppUser = await _usermanager.FindByNameAsync(User.Identity.Name);
                var userroles = await _usermanager.GetRolesAsync(AppUser);
                foreach (var item in userroles)
                {
                    if (item.ToLower() == "ban" || userroles == null)
                    {
                        await _signInManager.SignOutAsync();
                        return RedirectToAction("error", "home");
                    }
                }
            }
            Blog? blog = await _context?.Blogs?
                .FirstOrDefaultAsync(b => b.Id == id);
            BlogComment NewComment = new BlogComment();
            CommentsVM commentVM = new CommentsVM();
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                NewComment.AppUserId = user.Id;
                commentVM.UserId = user.Id;
            }
            else
            {
                NewComment.Author = author;
            }
            NewComment.CommentContent = comment;
            NewComment.BlogId = blog.Id;
            NewComment.Date = DateTime.Now;
            await _context.AddAsync(NewComment);
            await _context.SaveChangesAsync();
            commentVM.Comment = NewComment;
            return PartialView("_SingleComment", commentVM);
        }



        [Authorize]
        public async Task<IActionResult> DeleteComment(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser AppUser = await _usermanager.FindByNameAsync(User.Identity.Name);
                var userroles = await _usermanager.GetRolesAsync(AppUser);
                foreach (var item in userroles)
                {
                    if (item.ToLower() == "ban" || userroles == null)
                    {
                        await _signInManager.SignOutAsync();
                        return RedirectToAction("error", "home");
                    }
                }
            }
            AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
            BlogComment? comment = await _context?.BlogComments?.FirstOrDefaultAsync(bc => bc.Id == id);
            if (comment.AppUserId == user.Id)
            {
                comment.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            else
            {
                var roles = await _usermanager.GetRolesAsync(user);
                foreach (var item in roles)
                {
                    if (item.ToLower().Contains("admin") || item.ToLower().Contains("editor") || item.ToLower().Contains("moderator"))
                    {
                        comment.IsDeleted = true;
                        await _context.SaveChangesAsync();
                    }
                }
            }

            var obj = new
            {
                count = _context.BlogComments.Where(b => b.BlogId == comment.BlogId && !b.IsDeleted).ToList().Count
            };

            return Ok(obj);
        }
    }
}
