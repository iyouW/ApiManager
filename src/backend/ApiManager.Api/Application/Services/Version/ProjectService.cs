using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public class VersionService : IVersionService
    {
        private readonly IVersionRepository _repo;
        private readonly IDbContext _context;

        public VersionService(IVersionRepository repo, IDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public Task<Core.Entities.Version> GetByIdAsync(string id)
        {
            return _repo.GetByIdAsync(id);
        }

        public Task<IEnumerable<Core.Entities.Version>> GetListAsync()
        {
            return _repo.GetListAsync();
        }

        public async Task<Core.Entities.Version> AddAsync(Core.Entities.Version project)
        {
            _repo.Add(project);
            _ = await _context.SaveChangeAsync();
            return project;
        }
    }
}
