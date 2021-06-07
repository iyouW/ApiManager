using ApiManager.Api.Application.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public interface IProjectService
    {
        Task<Core.Entities.Project> AddAsync(Core.Entities.Project project);
        Task<Core.Entities.Project> GetByIdAsync(string id);
        Task<IEnumerable<Core.Entities.Project>> GetListAsync();
        Task<ProjectDetailResponse> GetDetailAsync(string projectId);
    }
}