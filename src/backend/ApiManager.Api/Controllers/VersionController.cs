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
    public class VersionController : ControllerBase
    {
        private readonly IVersionService _service;

        public VersionController(IVersionService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<IEnumerable<Core.Entities.Version>> List()
        {
            return _service.GetListAsync();
        }

        [HttpGet("{id}")]
        public Task<Core.Entities.Version> GetById(string id)
        {
            return _service.GetByIdAsync(id);
        }

        [HttpPost]
        public Task<Core.Entities.Version> Post(Core.Entities.Version request)
        {
            request.Id = Guid.NewGuid().ToString();
            return _service.AddAsync(request);
        }
    }
}
