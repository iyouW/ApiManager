using ApiManager.Core.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Core.Repositories
{
    public interface IRepositoryBase<T,TKey>
        where T : class, IEntityBase<TKey>
    {
        Task<IEnumerable<T>> GetListAsync();

        Task<IEnumerable<T>> GetListAsync(Expression<Func<T,bool>> expression);
        Task<T> GetByIdAsync(TKey id);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> expression);
    }
}
