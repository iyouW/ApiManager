using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _repo;
        private readonly IDbContext _context;

        public SubCategoryService(ISubCategoryRepository repo, IDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public Task<Core.Entities.SubCategory> GetByIdAsync(string id)
        {
            return _repo.GetByIdAsync(id);
        }

        public Task<IEnumerable<Core.Entities.SubCategory>> GetListAsync()
        {
            return _repo.GetListAsync();
        }

        public async Task<Core.Entities.SubCategory> AddAsync(Core.Entities.SubCategory project)
        {
            _repo.Add(project);
            _ = await _context.SaveChangeAsync();
            return project;
        }
    }
}
