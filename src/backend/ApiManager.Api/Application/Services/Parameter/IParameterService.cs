using ApiManager.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public interface IParameterService
    {
        Task<Parameter> AddAsync(Parameter project);
        Task<Parameter> GetByIdAsync(string id);
        Task<IEnumerable<Parameter>> GetListAsync();
    }
}