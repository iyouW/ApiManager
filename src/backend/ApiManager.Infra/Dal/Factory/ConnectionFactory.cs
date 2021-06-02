using ApiManager.Infra.Dal.Abstraction;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Dal.Factory
{
    public class ConnectionFactory : IConnectionFactory
    {
        public DalOptions Options { get; private set; }

        public ConnectionFactory(IOptionsMonitor<DalOptions> options)
        {
            Options = options.CurrentValue;
        }

        public IDbConnection Create()
        {
            return new MySqlConnection(Options.ConnectionString);
        }
    }
}
