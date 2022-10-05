using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class Slider
    {
        public int Id { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        public string ImageUrl { get; set; }
    }
}
