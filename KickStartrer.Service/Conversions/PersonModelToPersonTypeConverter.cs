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
            var person = new Person();

            // basic base entity properties
            person.Id = source.Id;

            person.FirstName = source.FirstName;
            person.MiddleName = source.MiddleName;
            person.Insertion = source.Insertion;
            person.LastName = source.LastName;
            person.Suffix = source.Suffix;
            person.Gender = source.Gender;
            person.DateOfBirth = source.DateOfBirth;
            person.SocialSegurityNumber = source.SocialSegurityNumber;
            person.Description = source.Description;
            //person.Image = source.Image;

            return person;
        }


    }
}
