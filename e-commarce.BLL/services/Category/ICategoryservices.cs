using ecommarce.BLL.DTOs;

namespace ecommarce.BLL.services;

public interface ICategoryservices
{
    Task< IEnumerable<CategorygetallDto>> Getall();
   Task <CategoryGetDto> GetAsync(Guid id);
    Task addcategory(CategoryAddDto category);
    Task deletecategory(Guid id);
    Task updatecategory(CategoryupdateDto category);

}
