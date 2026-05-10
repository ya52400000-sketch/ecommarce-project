using ecommarce.DAL.models;
using ecommarce.DAL.repository.GenricRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.DAL.repository;

public interface ICartRepo:IGenricRepo<Cart>
{
    Task ClearCartAsync(string userId);
    Task<Cart> GetCartWithItemsAsync(string userId);
}
