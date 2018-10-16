using AutoMapper;
using KickStarter.Library.Entities;
using KickStartrer.Service.ClientModels;
using KickStartrer.Service.Conversions;

namespace KickStartrer.Service
{
    /// <summary>
    /// Class for mapping profiles for Automapper.
    /// </summary>
    public class ClientModelToEntityMappingProfile : Profile
    {
        /// <summary>
        /// Creates the mapping frofiles for Model to Entity
        /// </summary>
        public ClientModelToEntityMappingProfile()
        {

            //CreateMap<Person, PersonModel>();

            CreateMap<PersonModel, Person>()
                .ConvertUsing<PersonModelToPersonTypeConverter>(); 

        }
    }
}
