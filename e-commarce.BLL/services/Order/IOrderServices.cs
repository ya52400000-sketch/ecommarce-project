using e_commarce.BLL.DTOs;
using ecommarce.BLL.DTOs;
using ecommarce.DAL.eunm;
using ecommarce.DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commarce.BLL.services;

public interface IOrderServices
{
    Task<IEnumerable<GetAllOrdersDto>> GetAllOrdersAsync(FilterOrderDto filter);

    Task<int> CreateOrderAsync(string userId);

    Task<GetOrderDto> GetOrderAsync(int orderId);

    Task CancelOrderAsync(int orderId, string userId);

    Task ChangeOrderStatusAsync(int orderId, OrderStatus status);

}
