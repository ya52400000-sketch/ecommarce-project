using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.DAL.models;

public class CartItem:BaseType<Guid>
{
    public Guid CartId { get; set; }
    public Cart Cart { get; set; }

    public Guid ProductId { get; set; }

    public Product product { get; set; }

    public string ProductName { get; set; }

    public decimal Price { get; set; } 

    public int Quantity { get; set; }
}
