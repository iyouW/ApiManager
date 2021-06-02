using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Core.Repositories
{
    public interface IRepositoryBase<T,TKey>
        where T : class
    {
        Task<IEnumerable<T>> GetListAsync();
        Task<T> GetByIdAsync(TKey id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
