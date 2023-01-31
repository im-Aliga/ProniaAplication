using BackEndFinalProject.Database.Models;
using BackEndFinalProject.Extensions;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BackEndFinalProject.Database
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantTag> PlantTags { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Navbar> Navbars { get; set; }
        public DbSet<SubNavbar> SubNavbars { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<PlantImage> PlantImages { get; set; }
        public DbSet<UserActivation> UserActivations { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PlantCatagory> PlantCatagories { get; set; }
        public DbSet<PlantColor> PlantColors { get; set; }
        public DbSet<PlantSize> PlantSizes { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogFile> BlogFiles { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogAndBlogTag> BlogAndBlogTags { get; set; }
        public DbSet<BlogAndBlogCategory> BlogAndBlogCategories { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly<Program>();
        }
    }
}
