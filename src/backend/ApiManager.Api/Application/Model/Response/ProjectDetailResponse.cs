using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Model.Response
{
    public class ProjectDetailResponse : Core.Entities.Project
    {
        public IEnumerable<ProxyDetailReponse>? Proxies { get; set; }
        public IEnumerable<ModuleDetailResponse>? Modules { get; set; }
    }
}
