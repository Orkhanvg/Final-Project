using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class Subjects
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public bool IsDeleted { get; set; }
        public List<BlogSubject>? BlogSubjects { get; set; }
    }
}
