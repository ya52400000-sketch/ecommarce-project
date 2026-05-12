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
    private readonly IProductRepo _productRepo;
    public CartServices(ICartRepo cartRepo, IProductRepo productRepo)
    {
        _cartRepo = cartRepo;
        _productRepo = productRepo;
    }
    public async Task AddToCartAsync(string userId, AddtoCartDto dto)
    {

        var product = await _productRepo.GetByIdAsync(dto.ProductId);
        if (product == null)
        {
            throw new Exception("Product not found");
        }

      
        var cart = await _cartRepo.GetCartWithItemsAsync(userId);

 
        if (cart == null)
        {
            cart = new Cart
            {
                UserId = userId,
                Items = new List<CartItem>()
            };
            await _cartRepo.AddAsync(cart);
            await _cartRepo.SaveChangesAsync();

        }

 
        var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == dto.ProductId);

        if (existingItem != null)
        {
    
            existingItem.Quantity += dto.Quantity;
    
            existingItem.Price = product.Price;
        }
        else
        {
      
            cart.Items.Add(new CartItem
            {
                ProductId = dto.ProductId,
                ProductName = product.Name,
                Quantity = dto.Quantity,
                Price = product.Price 
            });
        }

 
        await _cartRepo.SaveChangesAsync();
    }
    public async Task ClearCartAsync(string userId)
    {
        await _cartRepo.ClearCartAsync(userId);
        await _cartRepo.SaveChangesAsync();
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

    public async Task RemoveFromCartAsync(string userId, Guid productId)
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

    public async Task UpdateCartItemAsync(string userId, Guid productId, int quantity)
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
