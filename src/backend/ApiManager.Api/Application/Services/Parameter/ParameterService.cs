using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public class ParameterService : IParameterService
    {
        private readonly IParameterRepository _repo;
        private readonly IDbContext _context;

        public ParameterService(IParameterRepository repo, IDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public Task<Core.Entities.Parameter> GetByIdAsync(string id)
        {
            return _repo.GetByIdAsync(id);
        }

        public Task<IEnumerable<Core.Entities.Parameter>> GetListAsync()
        {
            return _repo.GetListAsync();
        }

        public async Task<Core.Entities.Parameter> AddAsync(Core.Entities.Parameter project)
        {
            _repo.Add(project);
            _ = await _context.SaveChangeAsync();
            return project;
        }
    }
}
