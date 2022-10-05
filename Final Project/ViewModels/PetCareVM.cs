using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels
{
    public class PetCareVM 
    {
        public AppUser User { get; set; }
        public string Question { get; set; }
        public string Care { get; set; }
        public string Map { get; set; }

    }
}
