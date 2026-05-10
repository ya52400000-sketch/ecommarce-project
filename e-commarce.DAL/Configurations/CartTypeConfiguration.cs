
using ecommarce.DAL.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommarce.DAL.Configurations;

public class CartTypeConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> Modelbuilder)
    {
        Modelbuilder.HasKey(c => c.Id);
        Modelbuilder.Property(c => c.Id).ValueGeneratedNever();
        Modelbuilder.HasMany(c => c.Items)
    .WithOne(i => i.Cart)
    .HasForeignKey(i => i.CartId);
        Modelbuilder.HasOne(c => c.User)
        .WithOne(u => u.Cart)
        .HasForeignKey<Cart>(c => c.UserId);
    }
}
