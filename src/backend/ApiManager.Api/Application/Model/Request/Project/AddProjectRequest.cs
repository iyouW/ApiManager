using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Model.Request.Project
{
    public class AddProjectRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
