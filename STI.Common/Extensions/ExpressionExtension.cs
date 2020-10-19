using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace STI.Common.Extensions
{
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Combines two Expressions using Or-Else conditional.
        /// </summary>
        /// <typeparam name="T">Type of source Expression's parameter.</typeparam>
        /// <param name="firstExpression">Left side of the new expression.</param>
        /// <param name="secondExpression">Right side of the new expression.</param>
        /// <returns>An expression with the two parameter expressions combined with Or-Else expression type</returns>
        public static Expression<Func<T, bool>> CombineOr<T>(this Expression<Func<T, bool>> firstExpression, Expression<Func<T, bool>> secondExpression)
        {
            return CombineExpressions(firstExpression, secondExpression, ExpressionType.OrElse);
        }

        public static Expression<Func<T, bool>> CombineAnd<T>(this Expression<Func<T, bool>> firstExpression, Expression<Func<T, bool>> secondExpression)
        {
            return CombineExpressions(firstExpression, secondExpression, ExpressionType.AndAlso);
        }

        private static Expression<Func<T, bool>> CombineExpressions<T>(Expression<Func<T, bool>> firstExpression, Expression<Func<T, bool>> secondExpression, ExpressionType type)
        {
            ParameterExpression parameter = firstExpression.Parameters[0];
            CombineExpressionVisitor visitor = new CombineExpressionVisitor();

            visitor.Sub[secondExpression.Parameters[0]] = parameter;
            Expression body = Expression.MakeBinary(type, firstExpression.Body, visitor.Visit(secondExpression.Body));

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
        public static void Each<T>(IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);
        }
        /// <summary>
        /// Class used to copy the expressions nodes and make parameters available in the expressions scope.
        /// </summary>
        private class CombineExpressionVisitor : ExpressionVisitor
        {
            public Dictionary<Expression, Expression> Sub = new Dictionary<Expression, Expression>();

            protected override Expression VisitParameter(ParameterExpression node)
            {
                Expression newNode;

                if (Sub.TryGetValue(node, out newNode))
                {
                    return newNode;
                }

                return node;
            }
        }


    }
}
