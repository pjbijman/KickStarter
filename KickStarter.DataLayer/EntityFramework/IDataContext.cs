using Microsoft.EntityFrameworkCore;
using KickStarter.Library.Entities;

namespace KickStarter.DataLayer.EntityFramework
{
    public interface IDataContext
    {
        DbSet<Person> Persons { get; set; }
    }
}