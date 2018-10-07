using Microsoft.EntityFrameworkCore;

namespace KickStarter.DataLayer.EntityFramework
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}