using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class SliderContent
    {
        public int Id { get; set; }
        public string Offer { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int SliderId { get; set; }
        public Slider Slider { get; set; }
    }
}
