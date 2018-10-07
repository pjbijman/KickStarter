using Microsoft.EntityFrameworkCore;
using KickStarter.Library.Entities;

namespace KickStarter.DataLayer.EntityFramework
{
    internal interface IDataContext
    {
        DbSet<Person> Persons { get; set; }
    }
}