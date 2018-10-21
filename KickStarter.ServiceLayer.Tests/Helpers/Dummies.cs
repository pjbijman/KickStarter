using KickStarter.Library.Entities;
using KickStarter.Library.Enums.Bandmate.Library.Enums;
using KickStartrer.Service.ClientModels;
using System;
using System.Collections.Generic;

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

        public static PersonModel GetDummiePersonModel(int type)
        {

            if (type < 0)
            {
                return null;
            }
            if (type == 0)
            {
                return new PersonModel();
            }
            else
            {
                return new PersonModel
                {
                    Id = Guid.NewGuid(),
                    DateOfBirth = DateTime.Now,
                    Description = "",
                    FirstName = "John",
                    Gender = Gender.Male,
                    //Image = null,
                    LastName = "Doe",
                    MiddleName = "",
                    SocialSegurityNumber = "123.456.789",
                    Suffix = "Sr."
                };
            }
        }

        /// <summary>
        /// type snaller then 0 returns Null, type == 0 returns new Object, type > 0 returns valid Object
        /// </summary>
        /// <param name="type"></param>
        public static List<Person> GetPeronList(int type)
        {
            List<Person> personlist;
            if (type < 0)
            {
                return null;
            }
            if (type == 0)
            {
                return new List<Person>();
            }
            else
            {
                personlist = new List<Person>();
                for (int i = 0; i < 10; i++)
                {
                    var person = new Person
                    {
                        Id = Guid.NewGuid(),
                        DateOfBirth = DateTime.Now.AddDays(i),
                        Description = string.Format("Description -{0}", i),
                        FirstName = string.Format("Jhon -{0}", i),
                        Gender = Gender.Male,
                        Image = null,
                        LastName = string.Format("Doe -{0}", i),
                        MiddleName = "",
                        SocialSegurityNumber = string.Format("123.456.789.{0}", i),
                        Suffix = "Sr."
                    };
                    personlist.Add(person);
                }
                return personlist;
            }
        }
    }
}
