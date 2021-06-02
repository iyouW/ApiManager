using ApiManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = ApiManager.Core.Entities.Version;

namespace ApiManager.Core.Repositories
{
    public interface IVersionRepository : IRepositoryBase<Version,string>
    {

    }
}
