using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public class ProxyService : IProxyService
    {
        private readonly IProxyRepository _repo;
        private readonly IDbContext _context;

        public ProxyService(IProxyRepository repo, IDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public Task<Core.Entities.Proxy> GetByIdAsync(string id)
        {
            return _repo.GetByIdAsync(id);
        }

        public Task<IEnumerable<Core.Entities.Proxy>> GetListAsync()
        {
            return _repo.GetListAsync();
        }

        public Task<IEnumerable<Core.Entities.Proxy>> GetListByProjectIdAsync(string projectId)
        {
            return _repo.GetListAsync(x => x.ProjectId == projectId);
        }

        public async Task<Core.Entities.Proxy> AddAsync(Core.Entities.Proxy project)
        {
            _repo.Add(project);
            _ = await _context.SaveChangeAsync();
            return project;
        }
    }
}
