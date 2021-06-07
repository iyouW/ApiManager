using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Core.Entities.Abstractions
{
    public interface IEntityBase<TKey>
    {
        TKey? Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime LatestUpdatedDate { get; set; }
        string? CreatedAccountId { get; set; }
        string? LatestUpdatedAccountId { get; set; }
    }
}
