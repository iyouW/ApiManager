using ApiManager.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public interface IModuleService
    {
        Task<Module> AddAsync(Module project);
        Task<Module> GetByIdAsync(string id);
        Task<IEnumerable<Module>> GetListAsync();
    }
}