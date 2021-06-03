using System;
using System.Linq.Expressions;
using ApiManager.Infra.Dal.Internal.Builder;
using DapperExtensions;

namespace ApiManager.Infra.Dal.Internal.ExpressionEx
{
    public static class ExpressionPredicateExtension
    {
        public static IPredicate? ToDapperPredicate<T>(this Expression<Func<T,bool>> expression)
            where T : class
        {
            return QueryBuilder<T>.FromExpression(expression);
        }
    }
}