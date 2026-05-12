using ecommarce.DAL.repository.GenricRepo;
using ecommarce.DAL.models;

namespace ecommarce.DAL.repository;

public interface IProductRepo:IGenricRepo<Product>
{
    Task <Product> GetProductAsync (Guid id);
    Task <IEnumerable<Product>> GetallproductsAsync(Product product);

}
