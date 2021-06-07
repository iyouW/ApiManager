using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Core.Entities.Abstractions
{
    public class EntityBase<TKey> : IEntityBase<TKey>
    {
        public TKey? Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LatestUpdatedDate { get; set; }
        public string? CreatedAccountId { get; set; }
        public string? LatestUpdatedAccountId { get; set; }
    }
}
