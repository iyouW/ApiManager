using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public interface IApiService
    {
        Task<Core.Entities.Api> AddAsync(Core.Entities.Api project);
        Task<Core.Entities.Api> GetByIdAsync(string id);
        Task<IEnumerable<Core.Entities.Api>> GetListAsync();
        Task<IEnumerable<Core.Entities.Api>> GetListWithinModuleAsync(string projectId, string moduleId);
    }
}