using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        [NotMapped]
        public IFormFile? Photo { get; set; }
        [NotMapped]
        public List<int>? SubjectsId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Author { get; set; }
        public int ViewCount { get; set; }
        public int? CommentCount { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public Nullable<DateTime> LastUpdated { get; set; }
        public string? LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public List<BlogSubject>? BlogSubjects { get; set; }
        public List<BlogComment>? Comments { get; set; }


    }
}
