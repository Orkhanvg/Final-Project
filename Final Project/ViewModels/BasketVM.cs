﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels
{
    public class BasketVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int ProductCount { get; set; }
        public string Desc { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
    }
}
