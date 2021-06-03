using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public class ApiService : IApiService
    {
        private readonly IApiRepository _repo;
        private readonly IDbContext _context;

        public ApiService(IApiRepository repo, IDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public Task<Core.Entities.Api> GetByIdAsync(string id)
        {
            return _repo.GetByIdAsync(id);
        }

        public Task<IEnumerable<Core.Entities.Api>> GetListAsync()
        {
            return _repo.GetListAsync();
        }

        public Task<IEnumerable<Core.Entities.Api>> GetListWithinModuleAsync(string projectId, string moduleId)
        {
            return _repo.GetListAsync(x => x.ProjectId == projectId && x.ModuleId == moduleId);
        }

        public async Task<Core.Entities.Api> AddAsync(Core.Entities.Api project)
        {
            _repo.Add(project);
            _ = await _context.SaveChangeAsync();
            return project;
        }
    }
}
