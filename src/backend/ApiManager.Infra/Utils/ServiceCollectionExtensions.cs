using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Utils
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterTransient(this IServiceCollection services, Assembly assembly, string pattern)
        {
            return services.RegisterDependency(assembly, pattern, (interf, impl) => services.TryAddTransient(interf, impl));
        }


        private static IServiceCollection RegisterDependency(this IServiceCollection services, Assembly assembly, string pattern, Action<Type, Type> register)
        {
            var types = assembly.ExportedTypes.Where(x => x.FullName?.EndsWith(pattern) ?? false);

            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces().Where(x => x.FullName?.EndsWith(pattern) ?? false);
                foreach (var interf in interfaces)
                {
                    register(interf, type);
                }
            }

            return services;
        }
    }
}
