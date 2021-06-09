using ApiManager.Api.Application.Model.Response;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Queries.Parameter
{
    public class ParameterQuery : IParameterQuery
    {
        private readonly IDbContext _context;
        public ParameterQuery(IDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<ParameterDetailResponse>> ListPureByApiIdAsync(IEnumerable<string> apiIds)
        {
            var sql = @"
SELECT
    *
FROM
    parameter
WHERE
    api_id IN @apiIds
ORDER BY
    created_date DESC
            ";

            var param = new
            {
                apiIds
            };

            return _context.QueryAsync<ParameterDetailResponse>(sql, param);
        }
    }
}
