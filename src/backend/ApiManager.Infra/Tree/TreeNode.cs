using ApiManager.Infra.Tree.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Tree
{
    public class TreeNode<Tkey> : ITreeNode<Tkey,TreeNode<Tkey>>
        where Tkey : IEquatable<Tkey>
    {
        public Tkey Id { get; set ; }
        public Tkey ParentId { get ; set; }
        public IEnumerable<TreeNode<Tkey>> Children { get ; set ; }
    }
}
