using ApiManager.Core.Entities;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.EntityMapper
{
    public class AppMapper : ClassMapper<App>
    {
        public AppMapper()
        {
            Table(nameof(App).ToLower());

            Map(p => p.Id).Column("id").Key(KeyType.Assigned);

            Map(p => p.Name).Column("name");

            Map(p => p.Description).Column("description");
        }
    }
}
