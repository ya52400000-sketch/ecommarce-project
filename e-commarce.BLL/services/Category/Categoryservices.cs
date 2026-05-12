using ecommarce.BLL.DTOs;
using ecommarce.DAL.models;
using ecommarce.DAL.repository;

namespace ecommarce.BLL.services;

public class Categoryservices : ICategoryservices
{
    private readonly ICategoryreop repo;

    public Categoryservices(ICategoryreop _repo)
    {
        repo = _repo;
    }
    public async Task addcategory(CategoryAddDto category)
    {


      
        var newcategory = new Category

        {
          
            Name = category.Name,
        };
       await repo.AddAsync(newcategory);
        await repo.SaveChangesAsync();
    }

    public async Task deletecategory(Guid id)
    {
      await repo.SoftDeleteAsync(id);
        await repo.SaveChangesAsync();
    }



    public async Task<IEnumerable<CategorygetallDto>> Getall()
    {
       var getcategories=await repo.GetAllAsync();
        var categorygetall = getcategories.Select(getcategories => new CategorygetallDto
        {
            Name = getcategories.Name
        });
        return categorygetall;
    }

    public async Task<CategoryGetDto> GetAsync(Guid id)
    {
        var get_category = await repo.GetByIdAsync(id);
        if (get_category == null)
        {
            return null!;
        }
        return new CategoryGetDto
        {
            Name = get_category.Name,
        };
    }

    public async Task updatecategory(CategoryupdateDto category)
    {
        var existcategory =await repo.GetByIdAsync(category.Id);
        if (existcategory != null && existcategory.IsDeleted == false) 
        {
            existcategory.Name = category.Name;
            repo.Update(existcategory);
            await repo.SaveChangesAsync();
        }
    }
}
