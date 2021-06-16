using ApiManager.Api.Application.Model.Request.Api;
using ApiManager.Api.Application.Services.Project;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IApiService _service;

        public ApiController(IApiService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<IEnumerable<Core.Entities.Api>> List()
        {
            return _service.GetListAsync();
        }

        [Route("/api/{projectId}/{moduleId}/[controller]")]
        [HttpGet]
        public Task<IEnumerable<Core.Entities.Api>> ListWithModule(string projectId, string moduleId)
        {
            return _service.GetListWithinModuleAsync(projectId, moduleId);
        }

        [HttpGet("{id}")]
        public Task<Core.Entities.Api> GetById(string id)
        {
            return _service.GetByIdAsync(id);
        }

        [HttpPost]
        public Task<Core.Entities.Api> Post(Core.Entities.Api request)
        {
            request.Id = Guid.NewGuid().ToString();
            return _service.AddAsync(request);
        }

        [HttpPut]
        public Task Put(UpdateApiRequest request)
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
