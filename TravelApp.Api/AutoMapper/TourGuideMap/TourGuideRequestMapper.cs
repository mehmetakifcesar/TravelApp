using AutoMapper;
using TravelApp.Entity.DTO.TourGuide;
using TravelApp.Entity.POCO;

namespace TravelApp.Api.AutoMapper.TourGuideMap
{
    public class TourGuideRequestMapper : Profile
    {
        public TourGuideRequestMapper()
        {
            CreateMap<TourGuide, TourGuideDTORequest>()
                .ForMember(dest => dest.FirstName, opt =>
                {
                    opt.MapFrom(src => src.FirstName);
                })
                .ForMember(dest => dest.LastName, opt =>
                {
                    opt.MapFrom(src => src.LastName);
                })
                .ForMember(dest => dest.PhoneNumber, opt =>
                {
                    opt.MapFrom(src => src.PhoneNumber);
                })
                .ForMember(dest => dest.Email, opt =>
                {
                    opt.MapFrom(src => src.Email);
                })
                .ForMember(dest => dest.PhoneNumber, opt =>
                {
                    opt.MapFrom(src => src.PhoneNumber);
                })
                .ForMember(dest => dest.Email, opt =>
                {
                    opt.MapFrom(src => src.Email);
                }).ReverseMap();

        }
    }
}
