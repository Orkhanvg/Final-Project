using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels
{
    public class BlogVM
    {
        [Required, MinLength(3, ErrorMessage = "Name can not be shorter than 3 letters"), MaxLength(35, ErrorMessage = "Name can not be longer than 35")]
        public string? Author { get; set; }
        [Required, MinLength(3, ErrorMessage = "Comment length can not be shorter than 3 letters"), MaxLength(500, ErrorMessage = "Comment length can not be longer than 500")]
        public string? CommentContent { get; set; }

        public AppUser? User { get; set; }
        public Blog? Blog { get; set; }
        public AppUser? CommentAuthor { get; set; }
        public List<BlogComment>? Comments { get; set; }

    }
}
