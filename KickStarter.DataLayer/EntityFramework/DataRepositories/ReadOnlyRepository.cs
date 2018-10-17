using Kickstarter.DataLayer.EntityFramework.Helpers;
using KickStarter.DataLayer.DI;
using KickStarter.Framework.Query;
using KickStarter.Library.Entities;
using KickStarter.Library.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KickStarter.DataLayer.EntityFramework.DataRepositories
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : BaseEntity // , IIdentifiable
    {
        public ReadOnlyRepository(DataContext dataContext)
        {
            InstanceGuid = Guid.NewGuid();
            DataContext = dataContext;
            DataSet = DataContext.Set<T>();
        }

        public Guid InstanceGuid { get; protected set; }
        protected DataContext DataContext { get; set; }
        protected DbSet<T> DataSet { get; set; }

        public async Task<QueryResult<T>> FindAllAsync()
        {
            var queryResult = new QueryResult<T>
            {
                Items = await DataSet.AsNoTracking().ToListAsync()
            };
            queryResult.TotalItems = queryResult.Items.Count();

            return queryResult;
        }

        public async Task<T> FindByIdAsync(Guid id)
        {
            var queryResult = await DataSet.AsNoTracking().Where(t => t.Id == id).FirstOrDefaultAsync();

            return queryResult;
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }

        public async Task<QueryResult<T>> QueryAsync(QueryCriteria<T> queryCriteria)
        {
            var queryResult = new QueryResult<T>();
            var dataSet = queryCriteria.AsNoTracking ? DataSet.AsNoTracking() : DataSet;
            queryResult.Items = await dataSet.ApplyQueryCriteria(queryCriteria).ToListAsync();

            return queryResult;
        }

        protected virtual T Map(T entity)
        {
            return entity;
        }
    }
}