using AutoMapper;
using TravelApp.Entity.DTO.Destination;
using TravelApp.Entity.POCO;

namespace TravelApp.Api.AutoMapper.DestinationMap
{
    public class DestinationRequestMapper : Profile
    {
        public DestinationRequestMapper()
        {
            CreateMap<Destination,DestinationDTORequest>()
                .ForMember(dest => dest.Name, opt =>
                {
                    opt.MapFrom(src => src.Name);
                })
                .ForMember(dest => dest.Description, opt =>
                {
                    opt.MapFrom(src => src.Description);
                })
                .ForMember(dest => dest.City, opt =>
                {
                    opt.MapFrom(src => src.City);
                })
                .ForMember(dest => dest.Country, opt =>
                {
                    opt.MapFrom(src => src.Country);
                }).ReverseMap();


        }
    }
}
