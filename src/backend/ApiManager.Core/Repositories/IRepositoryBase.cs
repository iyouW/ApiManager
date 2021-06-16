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
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>>? expression = null);
        Task<T> GetAsync(TKey id);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Update(T entity);
        void UpdatePartial(Expression<Func<T, bool>> expression, object properties);

        void Delete(TKey id);
        void Delete(Expression<Func<T, bool>> expression);
    }
}
