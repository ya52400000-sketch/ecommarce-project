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
      

        var random = new Random();

        var newProduct = new Product
        {
            Id = random.Next(1, 20),
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId
        };

       await _repo.AddAsync(newProduct);
    }

  
    public async Task Delete(int id)
    {
        var existing = await _repo.GetByIdAsync(id);

        if (existing == null)
            throw new Exception("Product not found");

        _repo.Delete(existing);
    }

   
    public async Task <IEnumerable<ProductGetallDto>> Getall()
    {
        var products = await _repo.GetAllAsync();

        return products.Select(p => new ProductGetallDto
        {
          
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            CategoryName = p.Category?.Name
        });
    }


    public async Task<ProductGetByIdDto> GetById(int id)
    {
        var p = await _repo.GetByIdAsync(id);

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

        if (product.CategoryId > 0)
            existing.CategoryId = product.CategoryId;

        _repo.Update(existing);
    }
}