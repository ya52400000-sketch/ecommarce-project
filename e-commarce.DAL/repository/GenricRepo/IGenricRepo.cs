using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.DAL.repository.GenricRepo;

public interface IGenricRepo<T> 
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task AddAsync(T item);
    Task Delete(T item);
    Task Update(T item);
    Task SaveChangesAsync();

}
