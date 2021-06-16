using ApiManager.Api.Application.Model.Request.Proxy;
using ApiManager.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public interface IProxyService
    {
        Task<Proxy> AddAsync(Proxy proxy);
        Task<Proxy> GetByIdAsync(string id);
        Task<IEnumerable<Proxy>> GetListAsync();
        Task<IEnumerable<Proxy>> GetListByProjectIdAsync(string projectId);
        Task UpdateAsync(UpdateProxyRequest request);
        Task DeleteAsync(string id);
    }
}