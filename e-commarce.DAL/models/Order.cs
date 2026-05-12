


using ecommarce.DAL.eunm;

namespace ecommarce.DAL.models;

public class Order:BaseType<Guid>
{
    public string UserId { get; set; }
    public AppUser User { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }

    public decimal TotalPrice { get; set; }

    public OrderStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

}
