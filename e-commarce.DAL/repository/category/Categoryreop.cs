using ecommarce.DAL.repository.GenricRepo;
using ecommarce.DAL.data;

using ecommarce.DAL.models;

namespace ecommarce.DAL.repository;

public class CategoryRepo : GenricRepo<Category>, ICategoryreop
{
    private readonly Appdbcontext _context;

    public CategoryRepo(Appdbcontext context) : base(context)
    {
        _context = context;
    }

    public async Task SoftDeleteAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null)
            throw new Exception("Category not found");

        category.IsDeleted = true;

        _context.Categories.Update(category);
    }
}