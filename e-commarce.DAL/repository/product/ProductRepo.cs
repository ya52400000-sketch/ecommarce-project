using ecommarce.DAL.repository.GenricRepo;
using ecommarce.DAL.data;
using ecommarce.DAL.models;
using Microsoft.EntityFrameworkCore;

namespace ecommarce.DAL.repository;

public class ProductRepo : GenricRepo<Product>,IProductRepo
{
    private readonly Appdbcontext _context;
    public ProductRepo(Appdbcontext context):base (context)
    {
        _context = context;
    }
  
}
