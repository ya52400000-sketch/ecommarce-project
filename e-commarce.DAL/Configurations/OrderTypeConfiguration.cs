

using ecommarce.DAL.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommarce.DAL.Configurations;

public class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> Modelbuilder)
    {
        Modelbuilder.HasKey(o => o.Id);
        Modelbuilder.Property(o=>o.Id).ValueGeneratedNever();
        Modelbuilder.HasMany(o => o.OrderItems)
    .WithOne(oi => oi.Order)
    .HasForeignKey(oi => oi.OrderId);
        Modelbuilder.HasOne(o => o.User)
        .WithMany(u => u.Orders)
        .HasForeignKey(o => o.UserId);
    }
}
