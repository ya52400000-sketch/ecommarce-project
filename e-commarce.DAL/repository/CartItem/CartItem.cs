using ecommarce.DAL.data;
using ecommarce.DAL.models;
using ecommarce.DAL.repository.GenricRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.DAL.repository;

public class CartItemRepo:GenricRepo<CartItem>,ICartItemRepo
{
    private readonly Appdbcontext _context;

    public CartItemRepo(Appdbcontext context) : base(context)
    {
        _context = context;
    }
}
