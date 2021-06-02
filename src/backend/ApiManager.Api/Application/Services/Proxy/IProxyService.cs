using ApiManager.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public interface IProxyService
    {
        Task<Proxy> AddAsync(Proxy project);
        Task<Proxy> GetByIdAsync(string id);
        Task<IEnumerable<Proxy>> GetListAsync();
    }
}