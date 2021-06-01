using ApiManager.Infra.Dal.Abstraction;
using ApiManager.Infra.Dal.Context;
using ApiManager.Infra.Dal.Factory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions.Sql;

namespace ApiManager.Infra.Dal
{
    public static class DalServiceCollectionExtensions
    {
        public static IServiceCollection AddDAL(this IServiceCollection services,IConfigurationSection section)
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            DapperExtensions.DapperExtensions.SqlDialect = new MySqlDialect();

            services.Configure<DalOptions>(section);

            services.TryAddTransient<IConnectionFactory,ConnectionFactory>();
            services.TryAddScoped<IDbContext, DbContext>();

            return services;
        }
    }
}
