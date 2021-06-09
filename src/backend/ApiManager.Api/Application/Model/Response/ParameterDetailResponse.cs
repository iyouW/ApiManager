using ApiManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Model.Response
{
    public class ParameterDetailResponse : Core.Entities.Parameter
    {
        public string TypeDesc => Type switch
        {
            ParameterType.Boolean => "Boolean",
            ParameterType.Number => "Number",
            ParameterType.String => "String",
            ParameterType.Array => "Array",
            ParameterType.Object => "Object",
            _ => string.Empty
        };

        public IEnumerable<ParameterDetailResponse> Children { get; set; } = Enumerable.Empty<ParameterDetailResponse>();
    }
}
