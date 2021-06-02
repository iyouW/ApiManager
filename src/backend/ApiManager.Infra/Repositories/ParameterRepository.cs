using ApiManager.Core.Entities;
using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Repositories
{
    public class ParameterRepository : RepositoryBase<Parameter, string>, IParameterRepository
    {
        public ParameterRepository(IDbContext context) : base(context)
        {
        }
    }
}
