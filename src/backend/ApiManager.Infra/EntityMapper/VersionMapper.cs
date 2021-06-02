using ApiManager.Core.Entities;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = ApiManager.Core.Entities.Version;

namespace ApiManager.Infra.EntityMapper
{
    public class VersionMapper : ClassMapper<Version>
    {
        public VersionMapper()
        {
            Table(nameof(Version).ToLower());

            Map(p => p.Id).Column("id").Key(KeyType.Assigned);

            Map(p => p.Name).Column("name");

            Map(p => p.Description).Column("description");
        }
    }
}
