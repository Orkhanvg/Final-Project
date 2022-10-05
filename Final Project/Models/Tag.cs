using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class Tag:BaseIdentity
    {
        public List<ProductTags> ProductTags { get; set; }
    }
}
