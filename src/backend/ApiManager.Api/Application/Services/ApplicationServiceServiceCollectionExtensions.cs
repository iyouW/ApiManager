using ApiManager.Api.Application.Services.Project;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services
{
    public static class ApplicationServiceServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.TryAddTransient<IProjectService, ProjectService>();
            return services;
        }
    }
}
