using ApiManager.Api.Application.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Queries.Parameter
{
    public interface IParameterQuery
    {
        Task<IEnumerable<ParameterDetailResponse>> ListPureByApiIdAsync(IEnumerable<string> apiIds);
    }
}