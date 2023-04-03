using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(500);
            builder.Property(e=>e.Description).IsRequired();
            builder.Property(e=>e.Price).HasColumnType("decimal");
            builder.Property(e => e.PictureUrl).IsRequired();
            builder.HasOne(e => e.Productbrand).WithMany().HasForeignKey(e => e.ProductBrandId);
            builder.HasOne(e => e.ProductType).WithMany().HasForeignKey(e => e.ProductTypeId);

        }
    }
}
