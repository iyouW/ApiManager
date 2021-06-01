using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Dal.Abstraction
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
