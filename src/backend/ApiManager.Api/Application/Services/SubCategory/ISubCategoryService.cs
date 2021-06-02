using ApiManager.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public interface ISubCategoryService
    {
        Task<SubCategory> AddAsync(SubCategory project);
        Task<SubCategory> GetByIdAsync(string id);
        Task<IEnumerable<SubCategory>> GetListAsync();
    }
}