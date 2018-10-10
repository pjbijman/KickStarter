using AutoMapper;
using KickStarter.Library.Entities;
using KickStarter.ServiceLayer.Servives.ClientModels;

namespace KickStarter.ServiceLayer
{
    public class ClientModelToEntityMappingProfile : Profile
    {
        public ClientModelToEntityMappingProfile()
        {

            CreateMap<Person, PersonModel>();

        }
    }
}
