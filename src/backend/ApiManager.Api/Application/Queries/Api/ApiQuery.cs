using ApiManager.Api.Application.Model.Response;
using ApiManager.Api.Application.Queries.Parameter;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Queries.Api
{
    public class ApiQuery : IApiQuery
    {
        private readonly IDbContext _context;
        private readonly IParameterQuery _paramQuery;

        public ApiQuery(IDbContext context, IParameterQuery paramQuery)
        {
            _context = context;
            _paramQuery = paramQuery;
        }

        public Task<IEnumerable<ApiDetailResponse>> ListPureWithinModuleAsync(string projectId, string moduleId)
        {
            var sql = @"
SELECT
    *
FROM
    api
WHERE
    project_id = @projectId
    AND module_id = @moduleId
            ";

            var param = new
            {
                projectId,
                moduleId
            };

            return _context.QueryAsync<ApiDetailResponse>(sql, param);
        }

        public async Task<IEnumerable<ApiDetailResponse>> ListDetailWithinModuleAsync(string projectId, string moduleId)
        {
            var apis = await ListPureWithinModuleAsync(projectId, moduleId);

            if (!apis.Any())
            {
                return apis;
            }

            var parameters = await _paramQuery.ListPureByApiIdAsync(apis.Select(x => x.Id ?? string.Empty));

            foreach (var api in apis)
            {
                api.Parameters = parameters.Where(x => x.ApiId == api.Id);
            }

            return apis;
        }
    }
}
