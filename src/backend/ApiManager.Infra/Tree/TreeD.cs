using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Tree
{
    public static class TreeD
    {
        public static IEnumerable<T> Compose<T>(IEnumerable<T> nodes, Func<T, bool> isRoot, Func<T, T, bool> isChild, Action<T, IEnumerable<T>> addChildren)
            where T : class
        {
            var roots = nodes.Where(x => isRoot(x));
            if (!roots.Any())
            {
                return roots;
            }
            ComposeCore(nodes, roots, isChild, addChildren);
            return roots;

            void ComposeCore(IEnumerable<T>  nodes, IEnumerable<T> parents, Func<T, T, bool> isChild, Action<T, IEnumerable<T>> addChildren)
            {
                foreach (var parent in parents)
                {
                    var children = nodes.Where(x => isChild(parent, x));
                    if (children.Any())
                    {
                        addChildren(parent, children);
                        ComposeCore(nodes, children, isChild, addChildren);
                    }
                }
            }
        }
    }
}
