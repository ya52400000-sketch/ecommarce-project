using ecommarce.DAL.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ecommarce.DAL.Configurations;

public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> Modelbuilder)
    {
        Modelbuilder.HasKey(p => p.Id);
        Modelbuilder.Property(c => c.Id).ValueGeneratedNever();
        Modelbuilder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        Modelbuilder.HasOne(p => p.Category).WithMany(c => c.products);
        Modelbuilder.HasData(
      new Product { Id = 1, Name = "Laptop", Price = 15000, Stock = 10, CategoryId = 1 },
      new Product { Id = 2, Name = "Smartphone", Price = 8000, Stock = 20, CategoryId = 1 },
      new Product { Id = 3, Name = "Headphones", Price = 500, Stock = 30, CategoryId = 1 },

      new Product { Id = 4, Name = "C# Programming Book", Price = 300, Stock = 40, CategoryId = 2 },
      new Product { Id = 5, Name = "Database Design Book", Price = 250, Stock = 35, CategoryId = 2 },

      new Product { Id = 6, Name = "T-Shirt", Price = 150, Stock = 50, CategoryId = 3 },
      new Product { Id = 7, Name = "Jeans", Price = 400, Stock = 25, CategoryId = 3 }
  );
    }
}
