using ecommarce.BLL.DTOs;

namespace ecommarce.BLL.services;

public interface IProductservices
{
   Task <IEnumerable<ProductGetallDto>> Getall();
    Task<ProductGetByIdDto> GetById(int id);
    Task Add(ProductAddDto product);
    Task Update(ProductUpdateDto product);
    Task Delete(int id);
}
