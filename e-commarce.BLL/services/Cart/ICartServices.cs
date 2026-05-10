using ecommarce.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.BLL.services;

public interface ICartServices
{
    Task<GetCartDto> GetCartAsync(string userId);

    Task AddToCartAsync(string userId, AddtoCartDto dto);

    Task UpdateCartItemAsync(string userId, int productId, int quantity);

    Task RemoveFromCartAsync(string userId, int productId);

    Task ClearCartAsync(string userId);
}
