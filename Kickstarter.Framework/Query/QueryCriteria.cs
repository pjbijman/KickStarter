using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;

namespace KickStarter.Framework.Query
{
    public class QueryCriteria<T> where T : class
    {
        public QueryCriteria()
        {
            Filter = PredicateExtensions.Begin<T>(true);
            IncludePaths = new List<IncludePath<T>>();
            OrderByFields = new List<OrderByField>();
            AsNoTracking = false;
            UseSoftDeleteFilter = true;
        }

        #region Filtering

        [IgnoreMap] public Expression<Func<T, bool>> Filter { get; set; }

        public QueryCriteria<T> WithFilter(Expression<Func<T, bool>> filter)
        {
            Filter = filter;
            return this;
        }

        public QueryCriteria<T> AndWhere(Expression<Func<T, bool>> filter)
        {
            Filter = Filter.And(filter);
            return this;
        }

        public QueryCriteria<T> OrWhere(Expression<Func<T, bool>> filter)
        {
            Filter = Filter.Or(filter);
            return this;
        }

        #endregion

        #region Sorting

        [IgnoreMap] public IList<OrderByField> OrderByFields { get; set; }

        public QueryCriteria<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderByFieldSelector, bool isAscending)
        {
            OrderByFields.Add(new OrderByField<T, TKey>(orderByFieldSelector, isAscending));
            return this;
        }

        #endregion

        #region Paging

        public bool UsePaging { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public int? TotalItems { get; set; }

        public QueryCriteria<T> Paging(int pageIndex, int pageSize)
        {
            UsePaging = true;
            PageIndex = pageIndex;
            PageSize = pageSize;
            return this;
        }

        #endregion

        #region Tracking

        public bool AsNoTracking { get; set; }

        public QueryCriteria<T> WithoutTracking()
        {
            AsNoTracking = true;
            return this;
        }

        public QueryCriteria<T> WithTracking()
        {
            AsNoTracking = false;
            return this;
        }

        #endregion

        #region Include Loading

        [IgnoreMap] public IList<IncludePath<T>> IncludePaths { get; set; }

        public QueryCriteria<T> Include<TKey>(Expression<Func<T, TKey>> path)
        {
            IncludePaths.Add(new IncludePath<T, TKey>(path));
            return this;
        }

        public bool ContainsRelation<TKey>(Expression<Func<T, TKey>> path)
        {
            return IncludePaths.Any(includePath => includePath.Contains(path));
        }

        #endregion

        #region GlobalFilterOptions

        public bool UseSoftDeleteFilter { get; set; }

        public QueryCriteria<T> WithSoftDeletedItems()
        {
            UseSoftDeleteFilter = false;
            return this;
        }

        #endregion
    }
}