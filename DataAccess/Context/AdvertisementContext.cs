using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess.Context
{
    public class AdvertisementContext : DbContext
    {
        public AdvertisementContext(DbContextOptions<AdvertisementContext> options) : base(options)
        {
            Database.EnsureDeleted(); // on program strart delete database
            Database.EnsureCreated(); // on program strart create database
        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureAdvertisementTable(modelBuilder);
            ConfigureCategoryTable(modelBuilder);
        }

        private void ConfigureAdvertisementTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertisement>().
                 Property(a => a.AdType).
                 HasConversion(
                     t => t.ToString(),
                     t => (AdType)Enum.Parse(typeof(AdType), t)
                 );

            modelBuilder.Entity<Advertisement>().HasData(
               new Advertisement()
               {
                   Id = 1,
                   AdType = AdType.TextAd,
                   Content = "Temp Content",
                   Cost = 10,
                   CategoryId = 1
               });
        }

        private void ConfigureCategoryTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category()
               {
                   Id = 1,
                   Name = "Test Category",
                   Description = "Temp description"
               });
        }
    }
}