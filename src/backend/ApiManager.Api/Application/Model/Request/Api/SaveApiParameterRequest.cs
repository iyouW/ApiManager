using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Model.Request.Api
{
    public class SaveApiParameterRequest
    {
        public ParameterTree? Input { get; set; }
        public ParameterTree? Output { get; set; }
        public ParameterTree? Exception { get; set; }
    }

    public class ParameterTree : Core.Entities.Parameter
    {
        public List<ParameterTree>? Children { get; set; }
    }
}
