using ecommarce.BLL.DTOs;
using ecommarce.BLL.DTOs.CartItem;
using ecommarce.DAL.models;
using ecommarce.DAL.repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.BLL.services;

public class CartServices : ICartServices
{
    private readonly ICartRepo _cartRepo;
    public CartServices(ICartRepo cartRepo)
    {
        _cartRepo = cartRepo;
    }
    public async Task AddToCartAsync(string userId, AddtoCartDto dto)
    {
        {
            var cart = await _cartRepo.GetCartWithItemsAsync(userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    Items = new List<CartItem>()
                };

                await _cartRepo.AddAsync(cart);
            }

            var item = cart.Items.FirstOrDefault(i => i.ProductId == dto.ProductId);

            if (item != null)
            {
                item.Quantity += dto.Quantity;
            }
            else
            {
                cart.Items.Add(new CartItem
                {
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity,
                    Price = dto.Price
                });
            }

            await _cartRepo.SaveChangesAsync();
        }
    }

    public async Task ClearCartAsync(string userId)
    {
        await _cartRepo.ClearCartAsync(userId);
    }

    public async Task<GetCartDto> GetCartAsync(string userId)
    {
        var cart =  await _cartRepo.GetCartWithItemsAsync(userId);

        if (cart == null)
            return new GetCartDto { UserId = userId, Items = new List<CartItemDto>() };

        return new GetCartDto
        {
            UserId = cart.UserId,
            Items = cart.Items.Select(i => new CartItemDto
            {
                ProductId = i.ProductId,
                ProductName = i.product.Name,
                Price = i.Price,
                Quantity = i.Quantity
            }).ToList()
        };
    }

    public async Task RemoveFromCartAsync(string userId, int productId)
    {
        var cart = await _cartRepo.GetCartWithItemsAsync(userId);

        if (cart == null)
            throw new Exception("Cart not found");

        var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);

        if (item == null)
            return;

        cart.Items.Remove(item);

        await _cartRepo.SaveChangesAsync();
    }

    public async Task UpdateCartItemAsync(string userId, int productId, int quantity)
    {
        var cart = await _cartRepo.GetCartWithItemsAsync(userId);

        if (cart == null)
            throw new Exception("Cart not found");

        var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);

        if (item == null)
            throw new Exception("Item not found");

        item.Quantity = quantity;

        await _cartRepo.SaveChangesAsync();
    }
}
