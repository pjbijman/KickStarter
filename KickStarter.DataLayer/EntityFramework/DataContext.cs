using KickStarter.DataLayer.Map;
using KickStarter.Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace KickStarter.DataLayer.EntityFramework
{
    public partial class DataContext : DbContext, IDataContext
    {
        public DataContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Leave this call, its for the initialisation of the identity tables.

            modelBuilder.AddConfiguration(new PersonMap());

        }

        #endregion

        #region Virtuals

        public virtual DbSet<Person> Persons { get; set; }

        #endregion
    }
}