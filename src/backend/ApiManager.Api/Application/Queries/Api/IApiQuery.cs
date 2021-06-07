using ApiManager.Api.Application.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Queries.Api
{
    public interface IApiQuery
    {
        Task<IEnumerable<ApiDetailResponse>> ListDetailWithinModuleAsync(string projectId, string moduleId);
        Task<IEnumerable<ApiDetailResponse>> ListPureWithinModuleAsync(string projectId, string moduleId);
    }
}