using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public class AppService : IAppService
    {
        private readonly IAppRepository _repo;
        private readonly IDbContext _context;

        public AppService(IAppRepository repo, IDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public Task<Core.Entities.App> GetByIdAsync(string id)
        {
            return _repo.GetByIdAsync(id);
        }

        public Task<IEnumerable<Core.Entities.App>> GetListAsync()
        {
            return _repo.GetListAsync();
        }

        public async Task<Core.Entities.App> AddAsync(Core.Entities.App project)
        {
            _repo.Add(project);
            _ = await _context.SaveChangeAsync();
            return project;
        }
    }
}
