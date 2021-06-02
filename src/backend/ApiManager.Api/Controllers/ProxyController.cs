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
    }
}
