﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .HasMany(s => s.Products)
                .WithMany(p => p.Sales)
                .UsingEntity<Dictionary<string, object>>(
                    "SaleProduct",
                    j => j.HasOne<Product>()
                          .WithMany()
                          .HasForeignKey("ProductId"),
                    j => j.HasOne<Sale>()
                          .WithMany()
                          .HasForeignKey("SaleId")
                );
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
