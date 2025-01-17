﻿using ApiManager.Api.Application.Model.Request.Api;
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
    public class ParameterController : ControllerBase
    {
        private readonly IParameterService _service;

        public ParameterController(IParameterService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<IEnumerable<Parameter>> List()
        {
            return _service.GetListAsync();
        }

        [Route("/api/{apiId}/[controller]")]
        [HttpGet]
        public Task<IEnumerable<Parameter>> ListWithinApi(string apiId)
        {
            return _service.GetListByApiIdAsync(apiId);
        }

        [HttpGet("{id}")]
        public Task<Parameter> GetById(string id)
        {
            return _service.GetByIdAsync(id);
        }

        [HttpPost]
        public Task<Parameter> Post(Parameter request)
        {
            request.Id = Guid.NewGuid().ToString();
            return _service.AddAsync(request);
        }

        [HttpPost("save")]
        public Task Save(SaveApiParameterRequest request)
        {
            return _service.SaveAsync(request);
        }
    }
}
