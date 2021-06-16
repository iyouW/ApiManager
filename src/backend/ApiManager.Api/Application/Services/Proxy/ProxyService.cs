using ApiManager.Api.Application.Model.Request.Proxy;
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
            return _repo.GetAsync(id);
        }

        public Task<IEnumerable<Core.Entities.Proxy>> GetListAsync()
        {
            return _repo.GetListAsync();
        }

        public Task<IEnumerable<Core.Entities.Proxy>> GetListByProjectIdAsync(string projectId)
        {
            return _repo.GetListAsync(x => x.ProjectId == projectId);
        }

        public async Task<Core.Entities.Proxy> AddAsync(Core.Entities.Proxy proxy)
        {
            _repo.Add(proxy);
            _ = await _context.SaveChangeAsync();
            return proxy;
        }

        public async Task UpdateAsync(UpdateProxyRequest request)
        {
            _repo.UpdatePartial(x =>x.Id == request.Id , request);
            _ = await _context.SaveChangeAsync();
        }

        public async Task DeleteAsync(string id)
        {
            _repo.Delete(id);
            _ = await _context.SaveChangeAsync();
        }
    }
}
