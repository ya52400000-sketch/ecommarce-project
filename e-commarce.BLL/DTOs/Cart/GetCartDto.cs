using ecommarce.BLL.DTOs.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.BLL.DTOs;

public class GetCartDto
{
   
        public string UserId { get; set; }

        public List<CartItemDto> Items { get; set; } = new();

        public decimal TotalPrice => Items.Sum(i => i.Total);
    
}
