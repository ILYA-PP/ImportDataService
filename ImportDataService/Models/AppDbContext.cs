using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportDataService.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<temp_city> Cities { get; set; }
        public virtual DbSet<temp_location> Pharmacies { get; set; }
        public virtual DbSet<temp_region> Regions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<temp_city>().ToTable("temp_city");
            modelBuilder.Entity<temp_location>().ToTable("temp_location");
            modelBuilder.Entity<temp_region>().ToTable("temp_region");
        }
    }
}
