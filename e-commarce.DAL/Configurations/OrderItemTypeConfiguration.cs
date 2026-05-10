using ecommarce.DAL.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.DAL.Configurations;

public class OrderItemTypeConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> Modelbuilder)
    {
        Modelbuilder.HasKey(oi => oi.Id);
        Modelbuilder.Property(oi=>oi.Id).ValueGeneratedNever();
        Modelbuilder.HasOne(oi => oi.product).WithMany(p => p.orderItems).HasForeignKey(oi => oi.ProductId);
    }
}
