using ecommarce.DAL.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.DAL.Configurations;

public class CartItemTypeConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> Modelbuilder)
    {
        Modelbuilder.HasKey(ci => ci.Id);
       
        Modelbuilder.HasOne(ci => ci.product)
    .WithMany(p => p.CartItems)
    .HasForeignKey(ci => ci.ProductId);
    }
}
