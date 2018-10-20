using KickStarter.Library.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KickStarter_Testdata
{
    public class Import
    {
        private readonly KickStarter.DataLayer.EntityFramework.DataContext _context;
        DefaultLists _defaultLists;
        private IConfiguration _configuration { get; set; }

        public Import(Boolean doInport, KickStarter.DataLayer.EntityFramework.DataContext context, IConfiguration configuration)
        {
            if (doInport)
            {
                _configuration = configuration;
                _context = context;

                _defaultLists = new DefaultLists();
                StartImport();
            }
        }

        private async Task StartImport()
        {
            await InsertPerson();

            Console.WriteLine("Done import.");
        }


        private async Task InsertPerson()
        {
            Console.WriteLine("Inserting persons.....");

            IEnumerable<Person> persons =  _defaultLists.Persons();
            _context.Persons.AddRange(persons);
            await _context.SaveChangesAsync();

            Console.WriteLine("Done inserting persons.");
        }
    }
}
