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

    Task UpdateCartItemAsync(string userId, Guid productId, int quantity);

    Task RemoveFromCartAsync(string userId, Guid productId);

    Task ClearCartAsync(string userId);
}
