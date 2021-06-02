using ApiManager.Core.Entities;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.EntityMapper
{
    public class ApiMapper : ClassMapper<Api>
    {
        public ApiMapper()
        {
            Table(nameof(Api).ToLower());

            Map(p => p.Id).Column("id").Key(KeyType.Assigned);

            Map(p => p.Name).Column("name");

            Map(p => p.Description).Column("description");

            Map(p => p.IsSupported).Column("is_supported");

            Map(p => p.IsParameterStandard).Column("is_parameter_standard");

            Map(p => p.MapName).Column("map_name");

            Map(p => p.ProjectId).Column("project_id");

            Map(p => p.ModuleId).Column("module_id");

            Map(p => p.ProxyId).Column("proxy_id");
        }
    }
}
