using ApiManager.Core.Entities;
using ApiManager.Infra.Tree.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Model.Response
{
    public class ParameterDetailResponse : Core.Entities.Parameter, ITreeNode<string, ParameterDetailResponse>
    {
        public string TypeDesc => Type switch
        {
            ParameterType.Boolean => nameof(ParameterType.Boolean),
            ParameterType.Number => nameof(ParameterType.Number),
            ParameterType.String => nameof(ParameterType.String),
            ParameterType.Array => nameof(ParameterType.Array),
            ParameterType.Object => nameof(ParameterType.Object),
            _ => string.Empty
        };

        public IEnumerable<ParameterDetailResponse> Children { get; set; } = Enumerable.Empty<ParameterDetailResponse>();
    }
}
