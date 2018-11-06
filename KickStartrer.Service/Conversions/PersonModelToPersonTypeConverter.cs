using AutoMapper;
using KickStarter.Library.Entities;
using KickStartrer.Service.ClientModels;

namespace KickStartrer.Service.Conversions
{
    /// <summary>
    /// Converts a PersonModel to a person Object
    /// </summary>
    public class PersonModelToPersonTypeConverter : ITypeConverter<PersonModel, Person>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Person Convert(PersonModel source, Person destination, ResolutionContext context)
        {
            var person = new Person
            {
                // basic base entity properties
                Id = source.Id,

                FirstName = source.FirstName,
                MiddleName = source.MiddleName,
                Insertion = source.Insertion,
                LastName = source.LastName,
                Suffix = source.Suffix,
                Gender = source.Gender,
                DateOfBirth = source.DateOfBirth,
                SocialSegurityNumber = source.SocialSegurityNumber,
                Description = source.Description,
                Image = source.Image
            };
            return person;
        }

        public PersonModel Convert(Person source, PersonModel destination, ResolutionContext context)
        {
            var personModel = new PersonModel
            {
                // basic base entity properties
                Id = source.Id,

                FirstName = source.FirstName,
                MiddleName = source.MiddleName,
                Insertion = source.Insertion,
                LastName = source.LastName,
                Suffix = source.Suffix,
                Gender = source.Gender,
                DateOfBirth = source.DateOfBirth,
                SocialSegurityNumber = source.SocialSegurityNumber,
                Description = source.Description,
                Image = source.Image
            };
            return personModel;
        }


    }
}
