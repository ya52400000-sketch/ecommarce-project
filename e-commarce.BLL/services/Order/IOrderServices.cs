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

    Task<Guid> CreateOrderAsync(string userId);

    Task<GetOrderDto> GetOrderAsync(Guid orderId);

    Task CancelOrderAsync(Guid orderId, string userId);

    Task ChangeOrderStatusAsync(Guid orderId, OrderStatus status);

}
