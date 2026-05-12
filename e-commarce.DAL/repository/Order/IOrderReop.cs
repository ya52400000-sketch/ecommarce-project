using ecommarce.DAL.models;
using ecommarce.DAL.repository.GenricRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ecommarce.DAL.repository;

public interface IOrderReop : IGenricRepo<Order>
{
  IQueryable<Order> GetAllQueryable();
    Task<Order> GetOrderWithItemsAsync(Guid id);
    Task<IEnumerable<Order>> GetUserOrdersWithItemsAsync(string userId);
}
