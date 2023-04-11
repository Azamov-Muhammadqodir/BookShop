using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Interfaces.RepositoryInterfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<T> AddAsync(T entity);
        public Task<T> AddRangeAsync(IEnumerable<T> entities);
        public Task<T> GetByIdAsync(int id);
        public Task<T> GetAllAsync();
        public Task<T> UpdateAsync(T entity);
        public Task<T> DeleteAsync(int id);
    }
}
