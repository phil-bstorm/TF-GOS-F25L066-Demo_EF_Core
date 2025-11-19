using DAL.Database.Configurations;
using DAL.Database.Seeds;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Database
{
    public class DbContextDemo : DbContext
    {
        #region Entités de la DB
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarOption> CarOptions { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Définition de la connection string
            // -> Setup pour une utilisation simple via l'opérateur "new"
            // https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/

            optionsBuilder.UseSqlServer("Data Source=BSTORM-PHIL\\DATAVIZ;database=Demo_EFCore;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandConfig());
            modelBuilder.ApplyConfiguration(new CarConfig());
            modelBuilder.ApplyConfiguration(new CarOptionConfig());

            modelBuilder.ApplyConfiguration(new BrandSeed());
            modelBuilder.ApplyConfiguration(new CarSeed());
            modelBuilder.ApplyConfiguration(new CarOptionSeed());

            modelBuilder.Entity("Car_CarOption")
                .HasData(
                    new {
                        CarId= 1,
                        OptionId = 1
                    },
                    new
                    {
                        CarId = 1,
                        OptionId = 2
                    },
                    new
                    {
                        CarId = 1,
                        OptionId = 3
                    },
                    new
                    {
                        CarId = 2,
                        OptionId = 1
                    }
                );
        }
    }
}
