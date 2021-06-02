using ApiManager.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public interface IVersionService
    {
        Task<Version> AddAsync(Version project);
        Task<Version> GetByIdAsync(string id);
        Task<IEnumerable<Version>> GetListAsync();
    }
}