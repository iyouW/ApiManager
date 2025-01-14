﻿using ApiManager.Api.Application.Model.Request.Module;
using ApiManager.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public interface IModuleService
    {
        Task<Module> AddAsync(Module project);
        Task<Module> GetByIdAsync(string id);
        Task<IEnumerable<Module>> GetListByProjectIdAsync(string projectId);
        Task<IEnumerable<Module>> GetListAsync();
        Task UpdateAsync(UpdateModuleRequest request);
        Task DeleteAsync(string id);
    }
}