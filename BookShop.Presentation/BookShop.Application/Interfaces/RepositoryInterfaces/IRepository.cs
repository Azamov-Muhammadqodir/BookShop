using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Interfaces.RepositoryInterfaces
{
    public interface IRepository<T> where T : class
    {
        public Task AddAsync(T entity);
        public Task AddRangeAsync(IEnumerable<T> entities);
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<bool> UpdateAsync(T entity);
        public Task DeleteAsync(int id);
    }
}
