using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ApiManager.Infra.Dal.Abstraction
{
    public interface IDbContext
    {
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param);
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param);
        Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param);
        Task<(IEnumerable<T1>, IEnumerable<T2>)> QueryMultiAsync<T1, T2>(string sql, object param);

        void AddCommand(Func<IDbConnection, IDbTransaction, Task> command);
        void AddCommands(IEnumerable<Func<IDbConnection, IDbTransaction, Task>> commands);

        Task<int> SaveChangeAsync();

        Task<T> GetAsync<T>(object id) where T : class;
        Task<IEnumerable<T>> GetListAsync<T>(object? predicate = null, IList<ISort>? sort = null) where T : class;
    }
}
