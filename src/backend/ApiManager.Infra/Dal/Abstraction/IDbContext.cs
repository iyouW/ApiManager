using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Dal.Abstraction
{
    public interface IDbContext
    {
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param);
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param);
        Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param);
        Task<T> InsertAsync<T>(T model) where T : class;
    }
}
