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

public class OrderRepo : GenricRepo<Order>,IOrderReop
{
    
    private readonly Appdbcontext _context;

    public OrderRepo(Appdbcontext context) : base(context)
    {
        _context = context;
    }

    public IQueryable<Order> GetAllQueryable()
    {
        return _context.Orders
            .Include(o => o.OrderItems);
    }


    public async Task<Order> GetOrderWithItemsAsync(Guid id)
    {
        return await _context.Orders.Include(o => o.OrderItems).ThenInclude(o => o.product) .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<Order>> GetUserOrdersWithItemsAsync(string userId)
    {
        return await _context.Orders
        .Include(o => o.OrderItems)
        .ThenInclude(oi => oi.product)
        .Where(o => o.UserId == userId)
        .ToListAsync();
    }
}