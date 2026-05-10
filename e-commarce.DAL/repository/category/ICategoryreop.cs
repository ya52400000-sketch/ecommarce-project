using ecommarce.DAL.repository.GenricRepo;
using ecommarce.DAL.models;

namespace ecommarce.DAL.repository;

public interface ICategoryreop : IGenricRepo<Category>
{
    Task SoftDeleteAsync(int id);
}
