using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace KickStarter.Framework.Query
{
    public class IncludePath<T> where T : class
    {
        private const string PathSeparator = ".";
        public readonly string IncludePathExpressionString;

        public IncludePath(LambdaExpression includePathExpression)
        {
            IncludePathExpression = includePathExpression;

            // cache the string, so this include path is evaluated once
            IncludePathExpressionString =
                string.Join(PathSeparator, CreateExpressionTreeStringList(includePathExpression));
        }

        public LambdaExpression IncludePathExpression { get; set; }

        /// <summary>
        ///     Checks whether the
        ///     <param name="includePathExpression">includePathExpression</param>
        ///     is part of the IncludePath
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="includePathExpression"></param>
        /// <returns></returns>
        public bool Contains<TKey>(Expression<Func<T, TKey>> includePathExpression)
        {
            var includePathExpressionString =
                string.Join(PathSeparator, CreateExpressionTreeStringList(includePathExpression));

            var isPartOf = IncludePathExpressionString.StartsWith(includePathExpressionString);
            return isPartOf;
        }

        /// <summary>
        ///     Method for creating a list of names of an IncludePath lambda expression,
        ///     it will only return the names of MemberExpressions and ik can handle Select methods for one to many relationship
        ///     parameter names in lambda expression as  (u=> u) will be ignored
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private IEnumerable<string> CreateExpressionTreeStringList(Expression expression)
        {
            var expressionTreeStringList = new List<string>();

            if (expression is LambdaExpression)
            {
                expressionTreeStringList.AddRange(
                    CreateExpressionTreeStringList((expression as LambdaExpression).Body));
            }
            else if (expression is MethodCallExpression)
            {
                // first argument is the part before the Select method
                expressionTreeStringList.AddRange(
                    CreateExpressionTreeStringList((expression as MethodCallExpression).Arguments[0]));
                // second argument is the body in the Select method
                expressionTreeStringList.AddRange(
                    CreateExpressionTreeStringList((expression as MethodCallExpression).Arguments[1]));
            }
            else if (expression is MemberExpression)
            {
                var memberExpression = expression as MemberExpression;

                expressionTreeStringList.AddRange(CreateExpressionTreeStringList(memberExpression.Expression));
                expressionTreeStringList.Add(memberExpression.Member.Name);
            }

            // else {other expression types will be ignored and will return an empty list}
            return expressionTreeStringList;
        }
    }

    public class IncludePath<T, TKey> : IncludePath<T> where T : class
    {
        public IncludePath(Expression<Func<T, TKey>> propertySelector)
            : base(propertySelector)
        {
            PropertySelector = propertySelector;
        }

        public Expression<Func<T, TKey>> PropertySelector { get; set; }
    }
}