﻿using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastrcuture.Data
{
    public class DBContext:DbContext
    {
        public DBContext()
        {

        }
        public DBContext(DbContextOptions<DBContext> options) :base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
