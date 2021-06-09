using ApiManager.Api.Application.Model.Response;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Queries.Project
{
    public class ProjectQuery : IProjectQuery
    {
        private readonly IDbContext _context;
        public ProjectQuery(IDbContext context)
        {
            _context = context;
        }

        public Task<ProjectDetailResponse> GetPureByIdAsync(string projectId)
        {
            var sql = @"
SELECT
    *
FROM
    project
WHERE
    id = @projectId
            ";

            var param = new
            {
                projectId
            };

            return _context.QuerySingleOrDefaultAsync<ProjectDetailResponse>(sql, param);
        }
    }
}
