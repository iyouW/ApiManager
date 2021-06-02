using ApiManager.Api.Application.Services.Project;
using ApiManager.Infra.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services
{
    public static class ApplicationServiceServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services.RegisterTransient(Assembly.GetExecutingAssembly(), "Service");
        }
    }
}
