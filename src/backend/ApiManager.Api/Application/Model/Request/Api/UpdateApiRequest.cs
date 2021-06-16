using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Model.Request.Api
{
    public class UpdateApiRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsSupported { get; set; }
        public bool IsParameterStandard { get; set; }
        public string? MapName { get; set; }
        public string ProxyId { get; set; }
        public string Author { get; set; }
        public string SupportedApp { get; set; }
    }
}
