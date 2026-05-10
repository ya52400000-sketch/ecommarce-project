using ecommarce.DAL.data;
using ecommarce.DAL.models;
using ecommarce.DAL.repository.GenricRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.DAL.repository;

public class OrderItemRepo:GenricRepo<OrderItem>,IOrderItemRepo
{
    private readonly Appdbcontext _context;

    public OrderItemRepo(Appdbcontext context) : base(context)
    {
        _context = context;
    }

}
