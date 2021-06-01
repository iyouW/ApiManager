using ApiManager.Infra.Dal.Abstraction;
using Dapper;
using DapperExtensions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Dal.Context
{
    public class DbContext : IDbContext
    {

        private IConnectionFactory _factory;

        public DbContext(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string sql, object param)
        {
            using (var conn = _factory.Create())
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                return conn.QueryAsync<T>(sql, param, null, null, null);
            }
        }

        public Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param)
        {
            using (var conn = _factory.Create())
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                return conn.QueryFirstOrDefaultAsync<T>(sql, param, null, null, null);
            }
        }

        public Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param)
        {
            using (var conn = _factory.Create())
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                return conn.QuerySingleOrDefaultAsync<T>(sql, param, null, null, null);
            }
        }

        public async Task<T> InsertAsync<T>(T model)
            where T : class
        {
            using (var conn = _factory.Create())
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                _ = await conn.InsertAsync<T>(model);
                return model;
            }
        }
    }
}
