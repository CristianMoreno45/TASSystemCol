using System.Linq.Expressions;

namespace UnalColombia.Common.Extensions.Lambda
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> CombineWith<T>(
            this Expression<Func<T, bool>> first,
            Expression<Func<T, bool>> second,
            ExpressionType mergeType)
        {
            var parameter = Expression.Parameter(typeof(T), "x");

            var left = Expression.Invoke(first, parameter);
            var right = Expression.Invoke(second, parameter);
            var combined = mergeType == ExpressionType.AndAlso
                ? Expression.AndAlso(left, right)
                : Expression.OrElse(left, right);

            return Expression.Lambda<Func<T, bool>>(combined, parameter);
        }
    }
}
