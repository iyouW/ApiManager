using ApiManager.Api.Application.Model.Response;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Queries.Proxy
{
    public class ProxyQuery : IProxyQuery
    {
        private readonly IDbContext _context;

        public ProxyQuery(IDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<ProxyDetailReponse>> GetPureByProjectIdAsync(string projectId)
        {
            var sql = @"
SELECT
    *
FROM
    proxy
WHERE
    project_id = @projectId
            ";

            var param = new
            {
                projectId
            };

            return _context.QueryAsync<ProxyDetailReponse>(sql, param);
        }
    }
}
