using ApiManager.Api.Application.Model.Request.Module;
using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _repo;
        private readonly IDbContext _context;

        public ModuleService(IModuleRepository repo, IDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public Task<Core.Entities.Module> GetByIdAsync(string id)
        {
            return _repo.GetAsync(id);
        }

        public Task<IEnumerable<Core.Entities.Module>> GetListAsync()
        {
            return _repo.GetListAsync();
        }

        public Task<IEnumerable<Core.Entities.Module>> GetListByProjectIdAsync(string projectId)
        {
            return _repo.GetListAsync(x => x.ProjectId == projectId);
        }

        public async Task<Core.Entities.Module> AddAsync(Core.Entities.Module project)
        {
            _repo.Add(project);
            _ = await _context.SaveChangeAsync();
            return project;
        }

        public async Task UpdateAsync(UpdateModuleRequest request)
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
