using ApiManager.Api.Application.Model.Request.Proxy;
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
    public class ProxyController : ControllerBase
    {
        private readonly IProxyService _service;

        public ProxyController(IProxyService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<IEnumerable<Proxy>> List()
        {
            return _service.GetListAsync();
        }
        
        [Route("/api/{projectId}/[controller]")]
        [HttpGet]
        public Task<IEnumerable<Proxy>> ListByProjectId(string projectId)
        {
            return _service.GetListByProjectIdAsync(projectId);
        }

        [HttpGet("{id}")]
        public Task<Proxy> GetById(string id)
        {
            return _service.GetByIdAsync(id);
        }

        [HttpPost]
        public Task<Proxy> Post(Proxy request)
        {
            request.Id = Guid.NewGuid().ToString();
            return _service.AddAsync(request);
        }

        [HttpPut]
        public Task Put(UpdateProxyRequest request)
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
