using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class BlogSubject
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int SubjectsId { get; set; }

        public Subjects? Subjects { get; set; }
        public Blog? Blog { get; set; }
    }
}
