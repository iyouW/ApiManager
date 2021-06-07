using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Model.Response
{
    public class ApiDetailResponse : Core.Entities.Api
    {
        public IEnumerable<Core.Entities.Parameter>? Parameters { get; set; }
        public ProxyDetailReponse? Proxy { get; set; }
        public IEnumerable<Core.Entities.Parameter> Input => Parameters.Where(x => x.Category == Core.Entities.ParameterCategory.Input);
        public IEnumerable<Core.Entities.Parameter> Output => Parameters.Where(x => x.Category == Core.Entities.ParameterCategory.Output);
        public IEnumerable<Core.Entities.Parameter> Exception => Parameters.Where(x => x.Category == Core.Entities.ParameterCategory.Exception);
        public string OperationName => string.IsNullOrWhiteSpace(MapName) ? Name : MapName;
    }
}
