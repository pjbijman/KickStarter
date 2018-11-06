using KickStarter.Library.Entities;
using KickStarter.Library.Enums.Bandmate.Library.Enums;
using KickStarter.Library.Interfaces;
using KickStartrer.Service.ClientModels;
using System;
using System.Collections.Generic;

namespace KickStarter.ServiceLayer.Tests.Helpers
{
    public static class Dummies
    {
        private static DateTime _dateOfBirth = new DateTime(1957, 08, 11);

        /// <summary>
        /// Enumereation fro determining the kind of object to return
        /// </summary>
        public enum DummieInstance
        {
            NullObject = 0,
            NewInstance = 1,
            ValidInstance = 2
        }

        /// <summary>
        /// dummieInstance == NullObject returns Null, dummieInstance == NewInstance returns new Person, dummieInstance == ValidInstance returns valid Person
        /// </summary>
        /// <param name="dummieInstance"></param>
        public static Person GetDummiePerson(DummieInstance dummieInstance)
        {
            Person person = new Person(); ;
            switch (dummieInstance)
            {
                case DummieInstance.NullObject:
                    person = null;
                    break;
                case DummieInstance.NewInstance:
                    person = new Person();
                    break;
                case DummieInstance.ValidInstance:
                    person = new Person
                    {
                        Id = Guid.NewGuid(),
                        DateOfBirth = _dateOfBirth,
                        Description = "",
                        FirstName = "John",
                        Gender = Gender.Male,
                        Image = Library.Helpers.Helpers.GetDummyImage(),
                        LastName = "Doe",
                        MiddleName = "",
                        SocialSegurityNumber = "123.456.789",
                        Suffix = "Sr.",
                        Insertion = ""
                    };
                    break;
                default:
                    break;
            }
            return person;
        }

        /// <summary>
        /// dummieInstance == NullObject returns Null, dummieInstance == NewInstance returns new PersonModel, dummieInstance == ValidInstance returns valid PersonModel>
        /// </summary>
        /// <param name="dummieInstance"></param>
        public static PersonModel GetDummiePersonModel(DummieInstance dummieInstance)
        {
            PersonModel personModel = new PersonModel();
            switch (dummieInstance)
            {
                case DummieInstance.NullObject:
                    personModel = null;
                    break;
                case DummieInstance.NewInstance:
                    personModel = new PersonModel();
                    break;
                case DummieInstance.ValidInstance:
                    personModel = new PersonModel
                    {
                        Id = Guid.NewGuid(),
                        DateOfBirth = _dateOfBirth,
                        Description = "",
                        FirstName = "John",
                        Gender = Gender.Male,
                        Image = Library.Helpers.Helpers.GetDummyImage(),
                        LastName = "Doe",
                        MiddleName = "",
                        SocialSegurityNumber = "123.456.789",
                        Suffix = "Sr.",
                        Insertion = ""
                    };
                    break;
                default:
                    break;
            }
            return personModel;
        }

        /// <summary>
        /// dummieInstance == NullObject returns Null, dummieInstance == NewInstance returns new List<Person>, dummieInstance == ValidInstance returns valid List<Person>
        /// </summary>
        /// <param name="dummieInstance"></param>
        public static List<Person> GetPeronList(DummieInstance dummieInstance)
        {
            List<Person> personlist = new List<Person>();

            switch (dummieInstance)
            {
                case DummieInstance.NullObject:
                    personlist = null;
                    break;
                case DummieInstance.NewInstance:
                    personlist = new List<Person>();
                    break;
                case DummieInstance.ValidInstance:
                    for (int i = 0; i < 10; i++)
                    {
                        Person person = new Person
                        {
                            Id = Guid.NewGuid(),
                            DateOfBirth = _dateOfBirth.AddDays(i),
                            Description = string.Format("Description -{0}", i),
                            FirstName = string.Format("Jhon -{0}", i),
                            Gender = Gender.Male,
                            Image = Library.Helpers.Helpers.GetDummyImage(),
                            LastName = string.Format("Doe -{0}", i),
                            MiddleName = "",
                            SocialSegurityNumber = string.Format("123.456.789.{0}", i),
                            Suffix = "Sr."
                        };
                        personlist.Add(person);
                    }
                    break;
            }

            return personlist;
        }
    }
}
