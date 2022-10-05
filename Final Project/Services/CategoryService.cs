using Final_Project.DAL;
using Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Services
{
    public class CategoryService : ICategory
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> Category()
        {
            List<Category> categories = _context.Categories
                .Include(p => p.Children)
                .Include(p => p.Products).Where(c => c.IsDeleted != true)
                .ToList();
            return categories;
        }

      
    }
}
