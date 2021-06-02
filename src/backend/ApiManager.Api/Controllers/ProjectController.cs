using ApiManager.Api.Application.Model.Request.Project;
using ApiManager.Api.Application.Services.Project;
using ApiManager.Core.Entities;
using ApiManager.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<IEnumerable<Project>> List()
        {
            return _service.GetListAsync();
        }

        [HttpGet("{id}")]
        public Task<Project> GetById(string id)
        {
            return _service.GetByIdAsync(id);
        }

        [HttpPost]
        public Task<Project> Post(AddProjectRequest request)
        {
            var proj = new Project
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Description = request.Description
            };
            return _service.AddAsync(proj);
        }
    }
}
