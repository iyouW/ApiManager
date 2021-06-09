using ApiManager.Core.Entities.Abstractions;
using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using ApiManager.Infra.Dal.Internal.ExpressionEx;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Repositories
{
    public class RepositoryBase<T, TKey> : IRepositoryBase<T, TKey>
        where T : class, IEntityBase<TKey>
    {
        protected IDbContext _context;

        public RepositoryBase(IDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<T>> GetListAsync()
        {
            return _context.GetListAsync<T>();
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression)
        {
            var sorts = new List<ISort>
            {
                new Sort
                {
                    PropertyName = "CreatedDate",
                    Ascending = false
                }
            };

            return await _context.GetListAsync<T>(expression, sorts);
        }

        public Task<T> GetByIdAsync(TKey id)
        {
            return _context.GetByIdAsync<T, TKey>(id);
        }

        public void Add(T entity)
        {
            entity.LatestUpdatedDate = entity.CreatedDate = DateTime.Now;
            _context.AddCommand((conn, trans) => conn.InsertAsync(entity));
        }

        public void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.LatestUpdatedDate = entity.CreatedDate = DateTime.Now;
            }
            _context.AddCommand((conn, trans) => conn.InsertAsync(entities));
        }

        public void Update(T entity)
        {
            entity.LatestUpdatedDate = DateTime.Now;
            _context.AddCommand((conn, trans) => conn.UpdateAsync(entity));
        }

        public void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            entity.LatestUpdatedDate = DateTime.Now;
            Update(entity);
        }

        public void Delete(T entity)
        {
            _context.AddCommand((conn, trans) => conn.DeleteAsync(entity));
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            var predicate = expression.ToDapperPredicate();
            _context.AddCommand((conn, trans) => conn.DeleteAsync<T>(predicate));
        }
    }
}
