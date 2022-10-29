using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class Bio
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        
        public string CouponCode { get; set; }
        public string SupportNumber { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string WorkTimes { get; set; }
        public string Author { get; set; }
        public string CardsImageUrl { get; set; }
        public string NewsLetterImgUrl { get; set; }
    }
}
