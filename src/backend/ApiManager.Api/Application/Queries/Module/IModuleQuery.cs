using ApiManager.Api.Application.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Queries.Module
{
    public interface IModuleQuery
    {
        Task<IEnumerable<ModuleDetailResponse>> ListPureByProjectIdAsync(string projectId);
        Task<IEnumerable<ModuleDetailResponse>> ListDetailByProjectIdAsync(string projectId);
    }
}