using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P23517082023HomeWork.Models;

namespace P23517082023HomeWork.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Car> Cars { get; set; }

    }
}
