using Final_Project.DAL;
using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels
{
    public class UserDetailVM
    {
        internal AppUser appUser;

        public int Id { get; set; }
        
        public List<Order> orders { get; set; }


    }
}
