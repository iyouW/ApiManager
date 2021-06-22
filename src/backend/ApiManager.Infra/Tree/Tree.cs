using ApiManager.Infra.Tree.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Tree
{
    public static class Tree<T, Tkey>
        where Tkey : IEquatable<Tkey>
        where T : ITreeNode<Tkey,T>
    {
        public static IEnumerable<T> Compose(IEnumerable<T> nodes)
        {
            var roots = nodes.Where(x => !nodes.Any(o => o.Id.Equals(x.ParentId)));
            if (!roots.Any())
            {
                return roots;
            }
            ComposeCore(nodes, roots);
            return roots;

            void ComposeCore(IEnumerable<T> nodes, IEnumerable<T> parents)
            {
                foreach (var parent in parents)
                {
                    var children = nodes.Where(x =>x.ParentId?.Equals(parent.Id) ?? false);
                    if (children.Any())
                    {
                        parent.Children = parent.Children.Union(children);
                        ComposeCore(nodes, children);
                    }
                }
            }
        }

        public static IEnumerable<T> Find(T node, Predicate<T> predicate)
        {
            var res = new List<T>();
            FindRecursive(node, predicate, res);
            return res;

            void FindRecursive(T node, Predicate<T> predicate, IList<T> result)
            {
                if (predicate(node))
                {
                    result.Add(node);
                }
                foreach (var child in node.Children)
                {
                    FindRecursive(child, predicate, result);
                }
            }
        }
    }
}
