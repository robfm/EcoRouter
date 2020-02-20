using EcoRouter.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EcoRouter.Data
{
    public class RouterContext : DbContext
    {
        public RouterContext(DbContextOptions<RouterContext> options) : base(options)
        {
        }

        public DbSet<RouteModel> Routes { get; set; }
        public DbSet<MapPointModel> Points { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<RouteModel>().ToTable("Routes");
            modelBuilder.Entity<MapPointModel>().ToTable("Marks");
            modelBuilder.Entity<UserModel>().ToTable("Users");
            modelBuilder.Entity<UserModel>().HasData(new UserModel { UserId = 1, UserName = "admin", Password = "admin", CreatedAt = DateTime.Now });
        }
    }
}