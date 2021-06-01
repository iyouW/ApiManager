using ApiManager.Core.Entities;
using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IDbContext _context;

        public ProjectRepository(IDbContext context)
        {
            _context = context;
        }

        public Task<Project> GetById(string id)
        {
            var sql = "select * from project where id = @id";
            return _context.QuerySingleOrDefaultAsync<Project>(sql, new { id });
        }

        public async Task<string> AddAsync(Project project)
        {
            var res = await _context.InsertAsync(project);
            return res.Id;
        }
    }
}
