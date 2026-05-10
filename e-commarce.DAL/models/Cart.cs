

namespace ecommarce.DAL.models;

public class Cart:BaseType<int>
{
    public string UserId { get; set; }

    public ICollection<CartItem> Items { get; set; }

    public AppUser User { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime CreatedAt { get; set; }

}
