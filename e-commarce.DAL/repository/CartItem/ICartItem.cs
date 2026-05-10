using ecommarce.DAL.models;
using ecommarce.DAL.repository.GenricRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.DAL.repository;

public interface ICartItemRepo:IGenricRepo<CartItem>
{
}
