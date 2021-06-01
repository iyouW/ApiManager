using ApiManager.Core.Entities;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.EntityMapper
{
    public class ProjectMapper : ClassMapper<Project>
    {
        public ProjectMapper()
        {
            Table("project");

            Map(p => p.Id).Column("id").Key(KeyType.Identity);

            Map(p => p.Name).Column("name");

            Map(p => p.Description).Column("description");
        }
    }
}
