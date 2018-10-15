using AutoMapper;
using KickStarter.Library.Entities;
using KickStartrer.Service.ClientModels;

namespace KickStartrer.Service
{
    public class ClientModelToEntityMappingProfile : Profile
    {
        public ClientModelToEntityMappingProfile()
        {

            CreateMap<Person, PersonModel>();

        }
    }
}
