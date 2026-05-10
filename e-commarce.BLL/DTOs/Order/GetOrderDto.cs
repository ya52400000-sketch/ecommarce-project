
using ecommarce.BLL.DTOs.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.BLL.DTOs;

public class GetOrderDto
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<OrderItemDto> Items { get; set; }

    public decimal TotalPrice => Items.Sum(i => i.Total);
}