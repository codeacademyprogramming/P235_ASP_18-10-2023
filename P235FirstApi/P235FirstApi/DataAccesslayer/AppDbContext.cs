using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using P235FirstApi.Configurations;
using P235FirstApi.Entities;

namespace P235FirstApi.DataAccesslayer
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //Seed Data
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Phone",
                    Image="sekil1.jpg"
                }, 
                new Category
                {
                    Id = 2,
                    Name = "Computer",
                    Image = "sekil1.jpg"
                },
                new Category
                {
                    Id = 3,
                    Name = "Televizor",
                    Image = "sekil1.jpg"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
