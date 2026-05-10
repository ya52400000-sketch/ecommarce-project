using ecommarce.DAL.models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommarce.DAL.models;

public class Product : BaseType<int>
{


    [MaxLength(100)]
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int Stock { get; set; }

    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public ICollection<OrderItem> orderItems { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
}



