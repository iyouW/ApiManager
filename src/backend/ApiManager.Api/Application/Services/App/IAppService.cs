using ApiManager.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public interface IAppService
    {
        Task<App> AddAsync(App project);
        Task<App> GetByIdAsync(string id);
        Task<IEnumerable<App>> GetListAsync();
    }
}