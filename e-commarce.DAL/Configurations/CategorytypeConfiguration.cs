using ecommarce.DAL.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ecommarce.DAL.Configurations
{
    public class CategorytypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> Modelbuilder)
        {
            Modelbuilder.HasKey(c => c.Id);
           
            
        Modelbuilder.Property(c => c.Name).IsRequired().HasMaxLength(100);
   
        }
    }
}
