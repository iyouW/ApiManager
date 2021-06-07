using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Model.Response
{
    public class ModuleDetailResponse : Core.Entities.Module
    {
        public IEnumerable<ApiDetailResponse>? Apis { get; set; }
    }
}
