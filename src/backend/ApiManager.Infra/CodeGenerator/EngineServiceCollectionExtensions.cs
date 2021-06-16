using ApiManager.Infra.CodeGenerator.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.CodeGenerator
{
    public static class EngineServiceCollectionExtensions
    {
        public static IServiceCollection AddCodeEngine(this IServiceCollection services)
        {


            services.TryAddTransient<ICodeGeneratorEngine, CodeGeneratorEngine>();
            return services;
        }
    }
}
