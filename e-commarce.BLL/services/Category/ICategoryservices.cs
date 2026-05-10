using ecommarce.BLL.DTOs;

namespace ecommarce.BLL.services;

public interface ICategoryservices
{
    Task< IEnumerable<CategorygetallDto>> Getall();
   Task <CategoryGetDto> GetAsync(int id);
    Task addcategory(CategoryAddDto category);
    Task deletecategory(int id);
    Task updatecategory(CategoryupdateDto category);

}
