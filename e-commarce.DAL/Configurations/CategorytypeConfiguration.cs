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
            Modelbuilder.Property(c => c.Id).ValueGeneratedNever();
            
        Modelbuilder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            Modelbuilder.HasData(
           new Category
           {
               Id = 1,
               Name = "Electronics",
               
               IsDeleted = false
           },
           new Category
           {
               Id = 2,
               Name = "Books",
              
               IsDeleted = false
           },
           new Category
           {
               Id = 3,
               Name = "Clothes",
              
               IsDeleted = false
           }
       );
        }
    }
}
