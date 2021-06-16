using ApiManager.Api.Application.Model.Request.Module;
using ApiManager.Api.Application.Services.Project;
using ApiManager.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _service;

        public ModuleController(IModuleService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<IEnumerable<Module>> List()
        {
            return _service.GetListAsync();
        }

        [Route("/api/{projectId}/[controller]")]
        [HttpGet]
        public Task<IEnumerable<Module>> ListByProjectId(string projectId)
        {
            return _service.GetListByProjectIdAsync(projectId);
        }

        [HttpGet("{id}")]
        public Task<Module> GetById(string id)
        {
            return _service.GetByIdAsync(id);
        }

        [HttpPost]
        public Task<Module> Post(Module request)
        {
            request.Id = Guid.NewGuid().ToString();
            return _service.AddAsync(request);
        }

        [HttpPut]
        public Task Put(UpdateModuleRequest request)
        {
            return _service.UpdateAsync(request);
        }

        [HttpDelete("{id}")]
        public Task Delete(string id)
        {
            return _service.DeleteAsync(id);
        }
    }
}
