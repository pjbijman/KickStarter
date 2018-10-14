using AutoMapper;
using KickStarter.BusinessLayer.Components.Interfaces;
using KickStarter.BusinessLayer.Components.Person;

namespace KickStarter.BusinessLayer.Components
{
    public class BusinessLayerMappingProfile : Profile
    {
        public BusinessLayerMappingProfile()
        {
            CreateMap<DeletePersonComponent, IDeletePersonComponent>();
            CreateMap<DeletePersonComponent, IGetPersonsComponent>();
            CreateMap<SavePersonComponent, ISavePersonComponent>();
        }
    }
}
