using ecommarce.DAL.data;
using ecommarce.DAL.models;
using ecommarce.DAL.repository.GenricRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.DAL.repository;

public class CartRepo : GenricRepo<Cart>, ICartRepo
{
    private readonly Appdbcontext _context;

    public CartRepo(Appdbcontext context) : base(context)
    {
        _context = context;
    }

    public async Task ClearCartAsync(string userId)
    {
        var cart = await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null || cart.Items == null || !cart.Items.Any())
            return;

        _context.CartItems.RemoveRange(cart.Items);

        await _context.SaveChangesAsync();
    }

    public async Task<Cart> GetCartWithItemsAsync(string userId)
    {
     return    await _context.Carts
      .Include(c => c.Items)
          .ThenInclude(i => i.product)
      .FirstOrDefaultAsync(c => c.UserId == userId);
    }
}
