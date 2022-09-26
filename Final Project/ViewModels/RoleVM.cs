using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels
{
    public class RoleVM
    {
        public string FullName { get; set; }
        public List<IdentityRole> roles { get; set; }
        public IList<string> userRoles { get; set; }
        public string UserId { get; set; }
    }
}
