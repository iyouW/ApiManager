using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Dal.Internal.Builder
{
    public static class QueryFunctions
    {
        public static bool Like(string pattern, object member)
        {
            throw new InvalidOperationException("For reflection only!");
        }
    }
}
