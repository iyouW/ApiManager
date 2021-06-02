using ApiManager.Core.Entities;
using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = ApiManager.Core.Entities.Version;

namespace ApiManager.Infra.Repositories
{
    public class VersionRepository : RepositoryBase<Version, string>, IVersionRepository
    {
        public VersionRepository(IDbContext context) : base(context)
        {
        }
    }
}
