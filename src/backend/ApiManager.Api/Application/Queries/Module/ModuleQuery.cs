using ApiManager.Api.Application.Model.Response;
using ApiManager.Api.Application.Queries.Api;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Queries.Module
{
    public class ModuleQuery : IModuleQuery
    {
        private readonly IDbContext _context;

        private readonly IApiQuery _apiQuery;

        public ModuleQuery(IDbContext context, IApiQuery apiQuery)
        {
            _context = context;
            _apiQuery = apiQuery;
        }

        public Task<IEnumerable<ModuleDetailResponse>> ListPureByProjectIdAsync(string projectId)
        {
            var sql = @"
SELECT
    *
FROM
    module
WHERE
    project_id = @projectId
            ";

            var param = new
            {
                projectId
            };

            return _context.QueryAsync<ModuleDetailResponse>(sql, param);
        }

        public async Task<IEnumerable<ModuleDetailResponse>> ListDetailByProjectIdAsync(string projectId)
        {
            var modules = await ListPureByProjectIdAsync(projectId);
            if (!modules.Any())
            {
                return modules;
            }

            foreach (var module in modules)
            {
                if (module.Id is not null)
                {
                    module.Apis = await _apiQuery.ListDetailWithinModuleAsync(projectId, module.Id);
                }
            }

            return modules;
        }
    }
}
