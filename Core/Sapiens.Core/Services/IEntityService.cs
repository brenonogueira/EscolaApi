using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapiens.Core.Services
{
    public interface IEntityService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task AddAsync(T t);
        void Update(T t);
        Task DeleteAsync(long id);
    }
}
