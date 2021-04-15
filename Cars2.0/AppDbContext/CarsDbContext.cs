using Microsoft.EntityFrameworkCore;
using Cars2._0.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace Cars2._0.AppDbContext
{
    public class CarsDbContext: IdentityDbContext<IdentityUser>
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options):
            base(options)
        {

        }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
