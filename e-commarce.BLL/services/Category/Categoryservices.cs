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


        var random = new Random();
        var newcategory = new Category

        {
            Id = random.Next(1,20),
            Name = category.Name,
        };
       await repo.AddAsync(newcategory);
    }

    public async Task deletecategory(int id)
    {
      await repo.SoftDeleteAsync(id);
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

    public async Task<CategoryGetDto> GetAsync(int id)
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
        }
    }
}
