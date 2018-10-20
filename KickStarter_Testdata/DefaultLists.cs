using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using KickStarter.DataLayer;
using KickStarter.Library.Entities;
using KickStarter.Library.Enums.Bandmate.Library.Enums;
using System.Threading.Tasks;

namespace KickStarter_Testdata
{
    public class DefaultLists
    {
 
        public DefaultLists()
        {
            
        }

        #region persons

        public IEnumerable<Person> Persons()
        {
            var _personList = new List<Person>();

            for (int i = 0; i < 25; i++)
            {
                _personList.Add(new Person
                {
                    Id = Guid.NewGuid(),
                    FirstName = string.Format("Peter {0} ", i),
                    LastName = string.Format("Verver {0}", i),
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(1957, 8, 11),
                });
            }

            return _personList;
        }

        #endregion
    }
}
