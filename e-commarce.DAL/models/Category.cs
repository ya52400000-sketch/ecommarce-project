using ecommarce.DAL.models;
using System.ComponentModel.DataAnnotations;

namespace ecommarce.DAL.models;

public class Category:BaseType<int>
{
    [Required]
    public string Name { get; set; }
    public bool IsDeleted { get; set; }=false;
    public ICollection<Product> products { get; set; }

}
