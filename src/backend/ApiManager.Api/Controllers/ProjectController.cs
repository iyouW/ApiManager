using ApiManager.Api.Application.Model.Request.Project;
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
        private readonly IProjectRepository _repo;

        public ProjectController(IProjectRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public Task<Project> GetById(string id)
        {
            return _repo.GetById(id);
        }

        [HttpPost]
        public Task<string> Post(AddProjectRequest request)
        {
            var proj = new Project
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Description = request.Description
            };
            return _repo.AddAsync(proj);
        }
    }
}
