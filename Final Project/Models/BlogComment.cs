using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class BlogComment
    {
     
            public int Id { get; set; }
            public string? CommentContent { get; set; }
            public string? Author { get; set; }
            public DateTime Date { get; set; }
            public bool IsDeleted { get; set; }


            public int BlogId { get; set; }
            public string? AppUserId { get; set; }
            public AppUser? User { get; set; }
            public Blog? Blog { get; set; }
        
    }
}
