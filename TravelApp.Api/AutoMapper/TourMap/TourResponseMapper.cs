using AutoMapper;
using TravelApp.Entity.DTO.Tour;
using TravelApp.Entity.POCO;

namespace TravelApp.Api.AutoMapper.TourMap
{
    public class TourResponseMapper : Profile
    {
        public TourResponseMapper()
        {
            CreateMap<Tour, TourDTOResponse>()

                .ForMember(dest => dest.Name, opt =>
                {
                    opt.MapFrom(src => src.Name);
                })
                .ForMember(dest => dest.Description, opt =>
                {
                    opt.MapFrom(src => src.Description);
                })
                .ForMember(dest => dest.StartingDate, opt =>
                {
                    opt.MapFrom(src => src.StartingDate);
                })
                .ForMember(dest => dest.EndingDate, opt =>
                {
                    opt.MapFrom(src => src.EndingDate);
                })
                .ForMember(dest => dest.Price, opt =>
                {
                    opt.MapFrom(src => src.Price);
                })
                 .ForMember(dest => dest.Guid, opt =>
                 {
                     opt.MapFrom(src => src.GUID);
                 }).ReverseMap();
        }
    }
}
