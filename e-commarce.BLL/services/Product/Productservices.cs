using ecommarce.DAL.models;
using ecommarce.DAL.repository;
using ecommarce.BLL.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ecommarce.BLL.services;

public class Productservices : IProductservices
{
    private readonly IProductRepo _repo;

    public Productservices(IProductRepo repo)
    {
        _repo = repo;
    }


    public async Task Add(ProductAddDto product)
    {
      


        var newProduct = new Product
        {
  
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId
        };

       await _repo.AddAsync(newProduct);
        await _repo.SaveChangesAsync();
    }

  
    public async Task Delete(Guid id)
    {
        var existing = await _repo.GetByIdAsync(id);

        if (existing == null)
            throw new Exception("Product not found");

        _repo.Delete(existing);
        await _repo.SaveChangesAsync();
    }

   
    public async Task <IEnumerable<ProductGetallDto>> Getall()
    {
        var products = await _repo.GetallproductsAsync(new Product());

        return products.Select(p => new ProductGetallDto
        {
          
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            CategoryName = p.Category?.Name
        });
    }


    public async Task<ProductGetByIdDto> GetById(Guid id)
    {
        var p = await _repo.GetProductAsync(id);

        if (p == null)
            return null;

        return new ProductGetByIdDto
        {
       
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            CategoryName = p.Category?.Name
        };
    }

    
    public async Task Update(ProductUpdateDto product)
    {
        var existing =await _repo.GetByIdAsync(product.Id);

        if (existing == null)
            throw new Exception("Product not found");

        if (!string.IsNullOrWhiteSpace(product.Name))
            existing.Name = product.Name;

        if (product.Price > 0)
            existing.Price = product.Price;

        if (product.Stock >= 0)
            existing.Stock = product.Stock;
            existing.CategoryId = product.CategoryId;
       await _repo.Update(existing);
        await _repo.SaveChangesAsync();
    }
}