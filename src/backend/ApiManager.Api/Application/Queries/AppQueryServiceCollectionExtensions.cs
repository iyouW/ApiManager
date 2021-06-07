using ApiManager.Infra.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Queries
{
    public static class AppQueryServiceCollectionExtensions
    {
        public static IServiceCollection AddAppQuery(this IServiceCollection services)
        {
            return services.RegisterTransient(Assembly.GetExecutingAssembly(), "Query");
        }
    }
}
