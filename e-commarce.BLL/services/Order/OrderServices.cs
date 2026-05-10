using e_commarce.BLL.DTOs;
using e_commarce.BLL.services;
using ecommarce.BLL.DTOs;
using ecommarce.BLL.DTOs.OrderItem;
using ecommarce.DAL.eunm;
using ecommarce.DAL.models;
using ecommarce.DAL.repository;
using Microsoft.EntityFrameworkCore;


namespace ecommarce.BLL.services;

public class OrderServices : IOrderServices
{
    private readonly IOrderReop _orderRepo;
    private readonly ICartRepo _cartRepo;
    public OrderServices(IOrderReop orderReop, ICartRepo cartRepo)
    {
        _orderRepo = orderReop;
        _cartRepo = cartRepo;
    }

    public async Task CancelOrderAsync(int orderId, string userId)
    {
        var order = await _orderRepo.GetByIdAsync(orderId);

        if (order == null)
            throw new Exception("Order not found");

   
        if (order.UserId != userId)
            throw new Exception("Not allowed");

        if (order.Status != OrderStatus.Pending)
            throw new Exception("Cannot cancel after processing");

        order.Status = OrderStatus.Cancelled;

        await _orderRepo.Update(order);
    }

    public async Task ChangeOrderStatusAsync(int orderId, OrderStatus status)
    {
        var order = await _orderRepo.GetByIdAsync(orderId);

        if (order == null)
            throw new Exception("Not found");

        order.Status = status;

        await _orderRepo.Update(order);
    }

    public async Task<int> CreateOrderAsync(string userId)
    {
        var cart = await _cartRepo.GetCartWithItemsAsync(userId);

        if (cart == null || !cart.Items.Any())
            throw new Exception("Cart is empty");

        var order = new Order
        {
            UserId = userId,
            Status = OrderStatus.Pending,
            CreatedAt = DateTime.UtcNow,
            OrderItems = cart.Items.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                Price = i.Price
            }).ToList()
        };

        await _orderRepo.AddAsync(order);

        await _cartRepo.ClearCartAsync(userId);

        return order.Id;
    }

    public async Task<IEnumerable<GetAllOrdersDto>> GetAllOrdersAsync(FilterOrderDto filter)
    {
        var query = _orderRepo.GetAllQueryable();

        if (!string.IsNullOrEmpty(filter.Status))
            query = query.Where(o => o.Status.ToString() == filter.Status);

        if (!string.IsNullOrEmpty(filter.UserId))
            query = query.Where(o => o.UserId == filter.UserId);

        if (filter.From.HasValue)
            query = query.Where(o => o.CreatedAt >= filter.From.Value);

        if (filter.To.HasValue)
            query = query.Where(o => o.CreatedAt <= filter.To.Value);

        return await query
            .Include(o => o.OrderItems)
            .ThenInclude(i => i.product)
            .Select(o => new GetAllOrdersDto
            {
                Id = o.Id,
                UserId = o.UserId,
                Status = o.Status.ToString(),
                CreatedAt = o.CreatedAt,
                TotalPrice = o.OrderItems.Sum(i => i.Price * i.Quantity)
            })
            .ToListAsync();
    }

    public async Task<GetOrderDto> GetOrderAsync(int orderId)
    {
        var order = await _orderRepo.GetOrderWithItemsAsync(orderId);

        if (order == null)
            throw new Exception("Order not found");

        return new GetOrderDto
        {
            Id = order.Id,
            UserId = order.UserId,
            Status = order.Status.ToString(),
            CreatedAt = order.CreatedAt,

            Items = order.OrderItems.Select(i => new OrderItemDto
            {
                ProductId = i.ProductId,
                ProductName = i.product.Name,
                Price = i.Price,
                Quantity = i.Quantity
            }).ToList()
        };
    }
}
