using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cars2._0.Models;



namespace Cars2._0.AppDbContext
{
    public class CarsDbContext: DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options):
            base(options)
        {

        }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}
