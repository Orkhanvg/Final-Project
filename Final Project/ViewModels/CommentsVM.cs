

using Final_Project.Models;
using System.Collections.Generic;

namespace Final_Project.ViewModels
{
    public class CommentsVM
    {
        public AppUser? User { get; set; }
        public List<BlogComment>? BlogComments { get; set; }
        public BlogComment? Comment { get; set; }
        public List<ProductComment>? ProductComments { get; set; }
        public ProductComment? ProductComment { get; set; }
        public int RightCounter { get; set; }
        public string? UserId { get; set; }
    }
}
