using ApiManager.Api.Application.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Queries.Proxy
{
    public interface IProxyQuery
    {
        Task<IEnumerable<ProxyDetailReponse>> GetPureByProjectIdAsync(string projectId);
    }
}