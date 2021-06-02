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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<IEnumerable<Category>> List()
        {
            return _service.GetListAsync();
        }

        [HttpGet("{id}")]
        public Task<Category> GetById(string id)
        {
            return _service.GetByIdAsync(id);
        }

        [HttpPost]
        public Task<Category> Post(Category request)
        {
            request.Id = Guid.NewGuid().ToString();
            return _service.AddAsync(request);
        }
    }
}
