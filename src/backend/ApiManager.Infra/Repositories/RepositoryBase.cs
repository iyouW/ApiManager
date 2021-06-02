﻿using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Repositories
{
    public class RepositoryBase<T, TKey> : IRepositoryBase<T, TKey>
        where T : class
    {
        private IDbContext _context;

        public RepositoryBase(IDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<T>> GetListAsync()
        {
            return _context.GetListAsync<T>();
        }

        public Task<T> GetByIdAsync(TKey id)
        {
            return _context.GetByIdAsync<T, TKey>(id);
        }

        public void Add(T entity)
        {
            _context.AddCommand((conn, trans) => conn.InsertAsync(entity));
        }

        public void Update(T entity)
        {
            _context.AddCommand((conn, trans) => conn.UpdateAsync(entity));
        }

        public void Delete(T entity)
        {
            _context.AddCommand((conn, trans) => conn.DeleteAsync(entity));
        }
    }
}