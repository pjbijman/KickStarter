using KickStarter.Library.Entities;
using KickStarter.Library.Enums.Bandmate.Library.Enums;
using KickStarter.ServiceLayer.Servives.ClientModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KickStarter.ServiceLayer.Tests.Helpers
{
    public static class Dummies
    {
        /// <summary>
        /// type snaller then 0 returns Null, type == 0 returns new Object, type > 0 returns valid Object
        /// </summary>
        /// <param name="type"></param>
        public static Person GetDummiePerson(int type)
        {

            if (type < 0)
            {
                return null;
            }
            if (type == 0)
            {
                return new Person();
            }
            else
            {
                return new Person
                {
                    Id = Guid.NewGuid(),
                    DateOfBirth = DateTime.Now,
                    Description = "",
                    FirstName = "John",
                    Gender = Gender.Male,
                    Image = null,
                    LastName = "Doe",
                    MiddleName = "",
                    SocialSegurityNumber = "123.456.789",
                    Suffix = "Sr."
                };
            }
        }
    }
}
