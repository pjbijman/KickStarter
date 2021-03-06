﻿using KickStarter.Library.Entities;
using KickStarter.Library.Enums.Bandmate.Library.Enums;
using KickStarter.Library.Interfaces;
using KickStarter.Library.Tests.Helpers;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Xunit;

namespace KickStarter.Library.Tests.Entities
{
    public class Person_Tests
    {

        /// <summary>
        /// Tests if all the required properties have the correct default value.
        /// </summary>
        [Fact]
        public void Test_Person_Constructor()
        {
            IPerson person = new Person();
            Assert.IsType<Person>(person);
            Assert.NotNull(person.Id);
            Assert.Null(person.FirstName);
            Assert.Null(person.Insertion);
            Assert.Null(person.LastName);
            Assert.Null(person.DateOfBirth);
            Assert.Null(person.SocialSegurityNumber);
            Assert.NotNull(person.Gender);
            Assert.True(person.Gender == Gender.Male);
            Assert.NotNull(person.InsertDate);
            Assert.NotNull(person.UpdateDate);
            Assert.NotNull(person.Image);
            Assert.Null(person.Description);
            Assert.True(person.FullName == string.Empty);
            Assert.Null(person.Error);
            Assert.True(person.IsValid == false);
        }

        /// <summary>
        /// Tests the person can be serialised.
        /// </summary>
        [Fact]
        public void Can_Person_be_Seralized()
        {
            IPerson person = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = String.Format("Person.FirstName"),
                LastName = String.Format("Person.LastName"),
                Insertion = String.Format("Person.Insertion"),
                Gender = Gender.Male,
                Description = String.Format("Person.Description"),
                SocialSegurityNumber = String.Format("Person.SocialSegurityNumber"),
                DateOfBirth = new DateTime(1957, 8, 11),

                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            string xmlFolder = TestHelper.xmlOutputFolder;
            string filePath = Path.Combine(xmlFolder, string.Format("{0}.xml", person.LastName));

            var file = new StreamWriter(filePath);

            var writer = new XmlSerializer(typeof(Person));
            writer.Serialize(file, person);
            file.Close();

            Assert.True(File.Exists(filePath));

            File.Delete(filePath);

            Assert.True(!File.Exists(filePath));
        }

        ///<summary>
        /// Tests the person can be de-serialised.
        /// </summary>
        [Fact]
        public void Can_Person_be_DeSeralized()
        {
            IPerson person = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = String.Format("Person.FirstName"),
                LastName = String.Format("Person.LastName"),
                Insertion = String.Format("Person.Insertion"),
                Gender = Gender.Male,
                Description = String.Format("Person.Description"),
                SocialSegurityNumber = String.Format("Person.SocialSegurityNumber"),
                DateOfBirth = new DateTime(1957, 8, 11),
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            string xmlFolder = TestHelper.xmlOutputFolder;
            string filePath = Path.Combine(xmlFolder, string.Format("{0}.xml", person.LastName));

            var file = new StreamWriter(filePath);

            var writer = new XmlSerializer(typeof(Person));
            writer.Serialize(file, person);
            file.Close();

            Assert.True(File.Exists(filePath));

            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    var xmlSerializer = new XmlSerializer(typeof(Person));

                    var pd = (Person)xmlSerializer.Deserialize(reader);

                    Assert.IsType<Person>(pd);
                }
            }

            Assert.True(File.Exists(filePath));

            File.Delete(filePath);

            Assert.True(!File.Exists(filePath));
        }

        [Fact]
        public void Test_Person_ToString()
        {
            IPerson person = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = String.Format("Person.FirstName"),
                LastName = String.Format("Person.LastName"),
                Insertion = String.Format("Person.Insertion"),
                Gender = Gender.Male,
                SocialSegurityNumber = String.Format("Person.SocialSegurityNumber"),
                DateOfBirth = new DateTime(1957, 8, 11),
                Description = String.Format("Person.Description"),
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            Assert.True(person.ToString() == person.FullName);
        }

        [Fact]
        public void Does_PersonId_raise_event_when_changed()
        {
            var result = false;
            IPerson person = new Person();

            person.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Id")
                {
                    result = true;
                }
            };

            person.Id = Guid.NewGuid();
            Assert.True(result);
        }

        [Fact]
        public void Does_Person_FirstName_raise_event_when_changed()
        {
            var result = false;
            IPerson person = new Person();

            person.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "FirstName")
                {
                    result = true;
                }
            };

            person.FirstName = "Person.FirstName";
            Assert.True(result);
        }

        [Fact]
        public void Does_Person_MiddleName_raise_event_when_changed()
        {
            var result = false;
            IPerson person = new Person();

            person.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "MiddleName")
                {
                    result = true;
                }
            };

            person.MiddleName = "Person.MiddleName";
            Assert.True(result);
        }

        [Fact]
        public void Does_Person_LastName_raise_event_when_changed()
        {
            var result = false;
            IPerson person = new Person();

            person.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "LastName")
                {
                    result = true;
                }
            };

            person.LastName = "Person.LastName";
            Assert.True(result);
        }

        [Fact]
        public void Does_Person_Insertion_raise_event_when_changed()
        {
            var result = false;
            IPerson person = new Person();

            person.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Insertion")
                {
                    result = true;
                }
            };

            person.Insertion = "Person.Insertion";
            Assert.True(result);
        }

        [Fact]
        public void Does_Person_Suffix_raise_event_when_changed()
        {
            var result = false;
            IPerson person = new Person();

            person.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Suffix")
                {
                    result = true;
                }
            };

            person.Suffix = "Person.Suffix";
            Assert.True(result);
        }

        [Fact]
        public void Does_Person_Gender_raise_event_when_changed()
        {
            var result = false;
            IPerson person = new Person();

            person.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Gender")
                {
                    result = true;
                }
            };

            person.Gender = Gender.Female;
            Assert.True(result);
        }

        [Fact]
        public void Does_Person_DateOfBirth_raise_event_when_changed()
        {
            var result = false;
            IPerson person = new Person();

            person.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "DateOfBirth")
                {
                    result = true;
                }
            };

            person.DateOfBirth = DateTime.Now;
            Assert.True(result);
        }

        [Fact]
        public void Does_Person_InsertDate_raise_event_when_changed()
        {
            var result = false;
            IPerson person = new Person();

            person.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "InsertDate")
                {
                    result = true;
                }
            };

            person.InsertDate = new DateTime(2015, 1, 1);
            Assert.True(result);
        }

        [Fact]
        public void Does_Person_Image_raise_event_when_changed()
        {
            var result = false;
            IPerson person = new Person();

            person.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Image")
                {
                    result = true;
                }
            };

            person.Image = null;
            Assert.True(result);
        }

        /// <summary>
        /// Tests the different propertie validations.
        /// </summary>
        [Fact]
        public void Test_Person_Validation()
        {
            IPerson person = new Person();
            Assert.IsType<Person>(person);
            Assert.NotNull(person.Id);
            Assert.Null(person.FirstName);
            Assert.Null(person.Insertion);
            Assert.Null(person.LastName);
            Assert.Null(person.DateOfBirth);
            Assert.Null(person.SocialSegurityNumber);
            Assert.NotNull(person.Gender);
            Assert.True(person.Gender == Gender.Male);
            Assert.NotNull(person.InsertDate);
            Assert.NotNull(person.UpdateDate);
            Assert.NotNull(person.Image);
            Assert.Null(person.Description);
            Assert.Null(person.Error);
            Assert.True(person.IsValid == false);

            //Check Validation collection for the correct key
            Assert.True(person.ValidationResults.ContainsKey("FirstName"));
            Assert.True(person.ValidationResults.ContainsKey("LastName"));
            Assert.True(person.ValidationResults.ContainsKey("DateOfBirth"));

            //Todo: Combine key and valye test
            //Assert.True(person.ValidationResults.Select(m => m.Key == "DateOfBirth" && m.Value.FirstOrDefault().Equals("Date Of Birth Required!")).FirstOrDefault());
            Assert.True(person.ValidationResults.Where(x => x.Value.Contains("First Name Required!")) != null);
            Assert.True(person.ValidationResults.Where(x => x.Value.Contains("Last Name Required!")) != null);
            Assert.True(person.ValidationResults.Where(x => x.Value.Contains("Date Of Birth Required!")) != null);

            Assert.True(person.IsValid == false);

            // Check for data length
            person.FirstName = TestHelper.RandomString(51);
            Assert.True(person.ValidationResults.Where(x => x.Value.Contains("Maximum 50 characters are allowed.")) != null);

            person.LastName = TestHelper.RandomString(51);
            Assert.True(person.ValidationResults.Where(x => x.Value.Contains("Maximum 50 characters are allowed.")) != null);

            person.Suffix = TestHelper.RandomString(51);
            Assert.True(person.ValidationResults.Where(x => x.Value.Contains("Maximum 50 characters are allowed.")) != null);

            person.Insertion = TestHelper.RandomString(51);
            Assert.True(person.ValidationResults.Where(x => x.Value.Contains("Maximum 50 characters are allowed.")) != null);

            Assert.True(person.IsValid == false);

            person.FirstName = "Person FirstName";
            person.LastName = "Person LastName";
            person.Suffix = "Person Suffix";
            person.Insertion = "Person Insertion";
            person.DateOfBirth = DateTime.Now;

            Assert.True(person.ValidationResults.Count() == 0);

            //Check the state
            Assert.True(person.IsValid == true);
        }

        [Fact]
        public void Does_Person_Description_raise_event_when_changed()
        {
            var result = false;
            IPerson person = new Person();

            person.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Description")
                {
                    result = true;
                }
            };

            person.Description = "Person.Description";
            Assert.True(result);
        }
    }
}
