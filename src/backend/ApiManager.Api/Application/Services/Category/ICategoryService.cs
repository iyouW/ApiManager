using ApiManager.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public interface ICategoryService
    {
        Task<Category> AddAsync(Category project);
        Task<Category> GetByIdAsync(string id);
        Task<IEnumerable<Category>> GetListAsync();
    }
}