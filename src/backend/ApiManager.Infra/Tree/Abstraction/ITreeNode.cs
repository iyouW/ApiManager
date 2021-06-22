using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Tree.Abstraction
{
    public interface ITreeNode<TKey, TChildren>
        where TKey : IEquatable<TKey>
        where TChildren : ITreeNode<TKey, TChildren>
    {
        TKey? Id { get; set; }
        TKey? ParentId { get; set; }
        IEnumerable<TChildren> Children { get; set; }
    }
}
