using Final_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels
{
    public class UserVM
    {
        public List<AppUser> Users { get; set; }
        public IList<string> userRoles { get; set; }
        public string UserId { get; set; }
    }
}
