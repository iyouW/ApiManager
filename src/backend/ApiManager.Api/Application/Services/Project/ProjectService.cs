using ApiManager.Api.Application.Model.Request.Project;
using ApiManager.Api.Application.Model.Response;
using ApiManager.Api.Application.Queries.Module;
using ApiManager.Api.Application.Queries.Project;
using ApiManager.Api.Application.Queries.Proxy;
using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repo;
        private readonly IProjectQuery _query;
        private readonly IModuleQuery _moduleQuery;
        private readonly IProxyQuery _proxyQuery;
        private readonly IDbContext _context;

        public ProjectService(IProjectRepository repo, IProjectQuery query, IModuleQuery moduleQuery, IProxyQuery proxyQuery, IDbContext context)
        {
            _repo = repo;
            _query = query;
            _moduleQuery = moduleQuery;
            _proxyQuery = proxyQuery;
            _context = context;
        }

        public Task<Core.Entities.Project> GetByIdAsync(string id)
        {
            return _repo.GetAsync(id);
        }

        public Task<IEnumerable<Core.Entities.Project>> GetListAsync()
        {
            return _repo.GetListAsync();
        }

        public async Task<Core.Entities.Project> AddAsync(Core.Entities.Project project)
        {
            _repo.Add(project);
            _ = await _context.SaveChangeAsync();
            return project;
        }

        public async Task<ProjectDetailResponse> GetDetailAsync(string projectId)
        {
            var project = await _query.GetPureByIdAsync(projectId);
            var modules = await _moduleQuery.ListDetailByProjectIdAsync(projectId);
            var proxies = await _proxyQuery.GetPureByProjectIdAsync(projectId);

            project.Modules = modules;
            project.Proxies = proxies;

            return project;
        }

        public async Task UpdateAsync(UpdateProjectRequest request)
        {
            _repo.UpdatePartial(x => x.Id == request.Id, request);
            _ = await _context.SaveChangeAsync();
        }

        public async Task DeleteAsync(string id)
        {
            _repo.Delete(id);
            _ = await _context.SaveChangeAsync();
        }
    }
}
