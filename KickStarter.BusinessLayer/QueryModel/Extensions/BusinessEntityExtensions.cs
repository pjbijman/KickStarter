using System.Linq;
using KickStarter.Library.Entities;

namespace KickStarter.BusinessLayer.QueryModel.Extensions
{
    public static class BusinessEntityExtensions
    {
        private const int DefaultPageSize = 10;
        private const int DefaultPageIndex = 0;

        public static IQueryable<T> UsePaging<T>(this IQueryable<T> entities, int? pageSize, int? pageIndex)
            where T : BaseEntity
        {
            if (!pageSize.HasValue) pageSize = DefaultPageSize;

            if (!pageIndex.HasValue) pageIndex = DefaultPageIndex;

            var skip = pageIndex * pageSize;
            entities = entities.Skip(skip.Value);
            entities = entities.Take(pageSize.Value);

            return entities;
        }
    }
}