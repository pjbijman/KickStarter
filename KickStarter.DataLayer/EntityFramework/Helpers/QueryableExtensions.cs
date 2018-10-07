using KickStarter.Framework.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Kickstarter.DataLayer.EntityFramework.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> ApplyQueryCriteria<TEntity>(this IQueryable<TEntity> source,
            QueryCriteria<TEntity> queryCriteria, QueryResult<TEntity> queryResult)
            where TEntity : class
        {
            return InternalApplyQueryCriteria(source, queryCriteria, queryResult);
        }

        public static IQueryable<TEntity> ApplyQueryCriteria<TEntity>(this IQueryable<TEntity> source,
            QueryCriteria<TEntity> queryCriteria)
            where TEntity : class
        {
            return InternalApplyQueryCriteria(source, queryCriteria, new QueryResult<TEntity>());
        }

        private static IQueryable<TEntity> InternalApplyQueryCriteria<TEntity>(this IQueryable<TEntity> source,
            QueryCriteria<TEntity> queryCriteria, QueryResult<TEntity> queryResult)
            where TEntity : class
        {
            if (queryCriteria.IncludePaths != null && queryCriteria.IncludePaths.Count > 0)
                source = queryCriteria.IncludePaths.Aggregate(source,
                    (current, includeField) => current.Include(includeField.IncludePathExpressionString));

            if (queryCriteria.Filter != null) source = source.Where(queryCriteria.Filter);

            if (queryCriteria.UsePaging) queryResult.TotalItems = source.Count();

            if (queryCriteria.OrderByFields != null && queryCriteria.OrderByFields.Count > 0)
            {
                var firstOrderByField = queryCriteria.OrderByFields.First();
                var orderedSource = source.OrderBy(firstOrderByField);
                orderedSource = queryCriteria.OrderByFields.Skip(1).Aggregate(orderedSource,
                    (current, orderByField) => current.ThenBy(orderByField));
                source = orderedSource;
            }

            if (queryCriteria.UsePaging)
            {
                var pageSize = queryCriteria.PageSize.HasValue && queryCriteria.PageSize.Value > 0
                    ? queryCriteria.PageSize.Value
                    : 10;
                var pageIndex = queryCriteria.PageIndex ?? 0;

                var skip = pageIndex * pageSize;

                source = source.Skip(skip);
                source = source.Take(pageSize);
            }

            return source;
        }

        public static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source,
            OrderByField orderByField)
            where TEntity : class
        {
            if (orderByField.PropertyExpression != null)
            {
                if (orderByField.IsAscending)
                    return Queryable.OrderBy(source, (dynamic) orderByField.PropertyExpression);
                return Queryable.OrderByDescending(source, (dynamic) orderByField.PropertyExpression);
            }

            return source.OrderBy(orderByField.PropertyName, orderByField.IsAscending);
        }

        public static IOrderedQueryable<TEntity> ThenBy<TEntity>(this IOrderedQueryable<TEntity> source,
            OrderByField orderByField)
            where TEntity : class
        {
            if (orderByField.PropertyExpression != null)
            {
                if (orderByField.IsAscending)
                    return Queryable.ThenBy(source, (dynamic) orderByField.PropertyExpression);
                return Queryable.ThenByDescending(source, (dynamic) orderByField.PropertyExpression);
            }

            return source.ThenBy(orderByField.PropertyName, orderByField.IsAscending);
        }

        public static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source,
            string orderByProperty, bool isAscending) where TEntity : class
        {
            var command = isAscending ? "OrderBy" : "OrderByDescending";

            var type = typeof(TEntity);

            var property = type.GetProperty(orderByProperty);

            var parameter = Expression.Parameter(type, "p");

            var propertyAccess = Expression.MakeMemberAccess(parameter, property);

            var orderByExpression = Expression.Lambda(propertyAccess, parameter);

            var resultExpression = Expression.Call(typeof(Queryable), command, new[] {type, property.PropertyType},
                source.Expression, Expression.Quote(orderByExpression));

            return source.Provider.CreateQuery<TEntity>(resultExpression) as IOrderedQueryable<TEntity>;
        }

        public static IOrderedQueryable<TEntity> ThenBy<TEntity>(this IOrderedQueryable<TEntity> source,
            string orderByProperty, bool isAscending) where TEntity : class
        {
            var command = isAscending ? "ThenBy" : "ThenByDescending";

            var type = typeof(TEntity);

            var property = type.GetProperty(orderByProperty);

            var parameter = Expression.Parameter(type, "p");

            var propertyAccess = Expression.MakeMemberAccess(parameter, property);

            var orderByExpression = Expression.Lambda(propertyAccess, parameter);

            var resultExpression = Expression.Call(typeof(Queryable), command, new[] {type, property.PropertyType},
                source.Expression, Expression.Quote(orderByExpression));

            return source.Provider.CreateQuery<TEntity>(resultExpression) as IOrderedQueryable<TEntity>;
        }
    }
}