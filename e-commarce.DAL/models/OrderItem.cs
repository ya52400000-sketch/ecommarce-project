

namespace ecommarce.DAL.models;

public class OrderItem:BaseType<int>
{
    public int OrderId { get; set; }
    public Order Order { get; set; }

    public int ProductId { get; set; }
    public Product product { get; set; }

    public string ProductName { get; set; } 

    public decimal Price { get; set; } 

    public int Quantity { get; set; }
}
