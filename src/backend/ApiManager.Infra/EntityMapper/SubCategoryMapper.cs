using ApiManager.Core.Entities;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.EntityMapper
{
    public class SubCategoryMapper : ClassMapper<SubCategory>
    {
        public SubCategoryMapper()
        {
            Table(nameof(SubCategoryMapper).ToLower());

            Map(p => p.Id).Column("id").Key(KeyType.Assigned);

            Map(p => p.Name).Column("name");

            Map(p => p.Description).Column("description");

            Map(p => p.ProjectId).Column("project_id");

            Map(p => p.CategoryId).Column("category_id");
        }
    }
}
