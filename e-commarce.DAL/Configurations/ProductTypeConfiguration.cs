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
     
        Modelbuilder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        Modelbuilder.HasOne(p => p.Category).WithMany(c => c.products);

    }
}
