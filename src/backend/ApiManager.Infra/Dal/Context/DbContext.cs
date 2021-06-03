using ApiManager.Infra.Dal.Abstraction;
using ApiManager.Infra.Dal.Internal.ExpressionEx;
using Dapper;
using DapperExtensions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Dal.Context
{
    public class DbContext : IDbContext
    {

        private IConnectionFactory _factory;

        private List<Func<IDbConnection, IDbTransaction, Task>> _commands = new List<Func<IDbConnection, IDbTransaction, Task>>();

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

        public Task<IEnumerable<T>> GetListAsync<T>(object? predicate = null, IList<ISort>? sort = null)
            where T : class
        {
            using var conn = _factory.Create();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            return conn.GetListAsync<T>(predicate, sort);
        }

        public Task<IEnumerable<T>> GetListAsync<T>(Expression<Func<T,bool>> expression , IList<ISort>? sort = null)
            where T : class
        {
            using var conn = _factory.Create();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            var predicate = expression.ToDapperPredicate();
            return conn.GetListAsync<T>(predicate, sort);
        }

        public Task<T> GetByIdAsync<T,TKey>(TKey id) where T : class
        {
            using (var conn = _factory.Create())
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                return  conn.GetAsync<T>(id);
            }
        }

        public void AddCommand(Func<IDbConnection, IDbTransaction, Task> command)
        {
            _commands.Add(command);
        }

        public void AddCommands(IEnumerable<Func<IDbConnection, IDbTransaction, Task>> commands)
        {
            _commands.AddRange(commands);
        }

        public async Task<int> SaveChangeAsync()
        {
            using var conn = _factory.Create();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            var trans = conn.BeginTransaction();
            try
            {
                foreach (var command in _commands)
                {
                    await command(conn, trans);
                }
                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
            }
            finally
            {
                trans.Dispose();
            }
            var res = _commands.Count;
            _commands.Clear();
            return res;
        }
    }
}
