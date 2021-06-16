using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperExtensions.PredicateExtensions
{
    public static class PredicateLinqExtensions
    {
        public static IPredicate ToPredicate<TEntity>(this Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            if (expression == null)
            {
                return null;
            }

            if (ExpressionUtility.IsConstant(expression, true))
            {
                return null;
            }

            if (ExpressionUtility.IsConstant(expression, false))
            {
                return null;
            }

            IPredicate pg = QueryBuilder<TEntity>.FromExpression(expression);

            return pg;
        }
    }
}
