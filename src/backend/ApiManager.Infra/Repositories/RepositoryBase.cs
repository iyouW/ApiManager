using ApiManager.Core.Entities.Abstractions;
using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using DapperExtensions;
using DapperExtensions.PredicateExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public Task<T> GetAsync(TKey id)
        {
            return _context.GetAsync<T>(id);
        }
        public Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>>? where = null)
        {
            where ??= x => !x.IsDeleted;
            var predicate = where.And(x => !x.IsDeleted).ToPredicate();
            var sort = new List<ISort>
            {
                new Sort
                {
                    PropertyName = nameof(IEntityBase<TKey>.CreatedDate),
                    Ascending = true
                }
            };
            return _context.GetListAsync<T>(predicate, sort);
        }

        public void Add(T entity)
        {
            entity.CreatedDate = entity.LatestUpdatedDate = DateTime.Now;
            _context.AddCommand((conn, trans) => conn.InsertAsync(entity, trans));
        }
        public void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreatedDate = entity.LatestUpdatedDate = DateTime.Now;
            }
            _context.AddCommand((conn, trans) => conn.InsertAsync(entities, trans));
        }

        public void Delete(TKey id)
        {
            Expression<Func<T, bool>> where = x => x.Id.Equals(id);
            Delete(where);
        }
        public void Delete(Expression<Func<T, bool>> expression)
        {
            var predicate = expression.And(x => !x.IsDeleted).ToPredicate();
            var props = new Dictionary<string, object>
            {
                [nameof(IEntityBase<TKey>.IsDeleted)] = true,
                [nameof(IEntityBase<TKey>.LatestUpdatedDate)] = DateTime.Now
            };
            _context.AddCommand((conn, trans) => conn.UpdatePartialAsync<T>(props, predicate, trans));
        }

        public void Update(T entity)
        {
            entity.LatestUpdatedDate = DateTime.Now;
            _context.AddCommand((conn, trans) => conn.UpdateAsync(entity, trans));
        }
        public void UpdatePartial(Expression<Func<T, bool>> where, object properties)
        {
            var predicate = where.And(x => !x.IsDeleted).ToPredicate();
            var props = ReflectionHelper.GetObjectValuesPlain(properties);
            props.TryAdd(nameof(IEntityBase<TKey>.LatestUpdatedDate), DateTime.Now);
            _context.AddCommand((conn, trans) => conn.UpdatePartialAsync<T>(props, predicate, trans));
        }
    }
}
