using Final_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.DAL
{

    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        } 
        public DbSet <Slider> Sliders { get; set; }
        
        public DbSet <SliderContent> SliderContents { get; set; }
        public DbSet <Banner> Banners { get; set; }
        public DbSet <Category> Categories { get; set; }
        public DbSet <Tag> Tags { get; set; }
        public DbSet <Brand> Brands { get; set; }
        public DbSet <Product> Products { get; set; }
        public DbSet <ProductImage> ProductImages { get; set; }
        public DbSet <ProductTags> ProductTags { get; set; }
        public DbSet <Order> Orders { get; set; }
        public DbSet <OrderItem> OrderItems { get; set; }
        public DbSet <BasketItem> BasketItems { get; set; }
        public DbSet <Bio> Bios { get; set; }
        public DbSet <Subscriber> Subscribers { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Gallery> Galleries { get; set; }

        public DbSet <Blog> Blogs { get; set; }

       
        public DbSet<BlogSubject>? BlogSubjects { get; set; }
        public DbSet<Subjects>? Subjects { get; set; }
        public DbSet<BlogComment>? BlogComments { get; set; }
        public DbSet<ProductComment>? ProductComments { get; set; }




    }
}
