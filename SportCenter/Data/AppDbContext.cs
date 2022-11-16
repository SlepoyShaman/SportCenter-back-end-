using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportCenter.Models.DataModels;
using SportCenter.Models.Identity;

namespace SportCenter.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        DbSet<Membership> Memberships { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Фитнес" },
                new Category { Id = 2, Name = "Тренажеры" },
                new Category { Id = 3, Name = "Йога" });
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Гантели 5кг", Img = "Gantels.jpg", Price = 599M, CategoryId = 1 },
                new Product { Id = 2, Name = "Коврик фирменный", Img = "Carpet.jpg", Price = 250M, CategoryId = 3 },
                new Product { Id = 3, Name = "Беговая дорожка", Img = "Treadmill.Jpg", Price = 24999M, CategoryId = 2 },
                new Product { Id = 4, Name = "Скакалка", Img = "SkippingRope.jpg", Price = 130M, CategoryId = 1 });
        }
    }
}
