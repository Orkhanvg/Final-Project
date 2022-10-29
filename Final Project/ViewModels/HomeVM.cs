using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Final_Project.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<SliderContent> SliderContents { get; set; }
        public List<Banner> Banners { get; set; }
        public List<Category> Categories { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public Product ProductDetail { get; set; }
        public  List<Blog> Blogs{ get; set; }
        public List<Team> Teams{ get; set; }
        public List <Gallery> Galleries{ get; set; }



    }
}
