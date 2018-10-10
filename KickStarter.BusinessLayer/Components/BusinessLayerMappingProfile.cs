using AutoMapper;

namespace KickStarter.BusinessLayer.Components
{
    public class BusinessLayerMappingProfile : Profile
    {
        public BusinessLayerMappingProfile()
        {
            //CreateMap<LifeguardBrigade, LifeguardBrigadeTreeItem>()
            //    .ForMember(dest => dest.ChildLifeguardBrigades, opt => opt.Ignore());

            //CreateMap<GlobalDocument, GlobalDocumentInfo>()
            //    .ReverseMap()
            //    .ForMember(dest => dest.File, opt => opt.Ignore());
        }
    }
}
