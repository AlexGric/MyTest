using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess.Context
{
    public class AdvertisementContext: DbContext 
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
        }

        private void ConfigureAdvertisementTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertisement>().
                 Property(a => a.AdType).
                 HasConversion(
                     t => t.ToString(),
                     t => (AdType)Enum.Parse(typeof(AdType), t)
                 );
        }
    }
}
