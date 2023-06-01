using AutoMapper;
using SeaBreeze.Domain.Entity.Stories;
using SeaBreeze.Domain.Entity.Users;
using SeaBreeze.Service.DTOS.Consumer;
using SeaBreeze.Service.DTOS.Story;
using SeaBreeze.Service.DTOS.User;

namespace SeaBreeze.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, RegisterConsumerDto>().ReverseMap();
            CreateMap<AppUser, RegisterResidentDto>().ReverseMap();

            CreateMap<Stories, StoryDetailDto>()
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.StoriesTranslates[0].ImageUrl))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StoriesTranslates[0].Name))
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.StoriesTranslates[0].Location))
            .ForMember(dest => dest.Desciription, opt => opt.MapFrom(src => src.StoriesTranslates[0].Description));
        }
    }
}
