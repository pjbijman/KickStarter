using KickStarter.BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace KickStarter.BusinessLogic.Services
{
    public class BaseBL : IBaseBLL
    {
        //ToDo: Handle contect disposing with DI.

        //DbContextOptions opt = new DbContextOptions{;
        //private DbContext context = new DbContext();

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) { }
                //if (context != null)
                //{
                //    context.Dispose();
                //    context = null;
                //}
        }

        ~BaseBL()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
