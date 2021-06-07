using ApiManager.Api.Application.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Queries.Project
{
    public interface IProjectQuery
    {
        Task<ProjectDetailResponse> GetPureByIdAsync(string projectId);
    }
}