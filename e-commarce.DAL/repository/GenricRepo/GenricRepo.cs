using ecommarce.DAL.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.DAL.repository.GenricRepo
{
    public class GenricRepo<T> : IGenricRepo<T> where T : class
    {
        private readonly Appdbcontext _context;
        public GenricRepo(Appdbcontext context)
        {
            _context = context;
        }
        public async Task AddAsync(T item)
        {
           await _context.Set<T>().AddAsync(item);
          
        }

        public async Task Delete(T item)
        {
            _context.Set<T>().Remove(item);
        
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id) ?? null;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(T item)
        {
          _context.Update(item);
            
        }
    }
}
