using KickStarter.DataLayer.DI;
using KickStarter.DataLayer.EntityFramework;
using System;
using System.Threading.Tasks;

namespace QuotationTool.DataLayer.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            InstanceGuid = Guid.NewGuid();
            _dataContext = dataContext;
        }

        public Guid InstanceGuid { get; protected set; }

        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_dataContext != null) _dataContext.Dispose();
        }

       
    }
}