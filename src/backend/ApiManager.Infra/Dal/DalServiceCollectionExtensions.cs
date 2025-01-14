﻿using ApiManager.Infra.Dal.Abstraction;
using ApiManager.Infra.Dal.Context;
using ApiManager.Infra.Dal.Factory;
using Dapper;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;
using System.Reflection;

namespace ApiManager.Infra.Dal
{
    public static class DalServiceCollectionExtensions
    {
        public static IServiceCollection AddDAL(this IServiceCollection services,IConfigurationSection section)
        {
            ConfigureDapper();
            ConfigureDapperExtensions();

            services.Configure<DalOptions>(section);

            services.TryAddTransient<IConnectionFactory,ConnectionFactory>();
            services.TryAddScoped<IDbContext, DbContext>();

            return services;

            void ConfigureDapper()
            {
                DefaultTypeMap.MatchNamesWithUnderscores = true;
            }

            void ConfigureDapperExtensions()
            {
                var dialect = new MySqlDialect();
                var asemblies = new List<Assembly>{Assembly.GetExecutingAssembly()};
                var mapper = typeof(ClassMapper<>);

                DapperExtensions.DapperExtensions.Configure(mapper, asemblies, dialect);
                DapperExtensions.DapperAsyncExtensions.Configure(mapper, asemblies, dialect);
            }
        }
    }
}
