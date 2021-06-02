using ApiManager.Core.Repositories;
using ApiManager.Infra.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Repositories
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            return services.RegisterTransient(Assembly.GetExecutingAssembly(),"Repository");
        }
    }
}
