using AutoMapper;
using TravelApp.Entity.DTO.Hotel;
using TravelApp.Entity.POCO;

namespace TravelApp.Api.AutoMapper.HotelMap
{
    public class HotelResponseMapper : Profile
    {
        public HotelResponseMapper()
        {
            CreateMap<Hotel, HotelDTOResponse>()
                .ForMember(dest => dest.Name, opt =>
                {
                    opt.MapFrom(src => src.Name);
                })
                .ForMember(dest => dest.NumberOfTravelers, opt =>
                {
                    opt.MapFrom(src => src.NumberOfTravelers);
                })
                .ForMember(dest => dest.RoomNumber, opt =>
                {
                    opt.MapFrom(src => src.RoomNumber);
                })
                .ForMember(dest => dest.ReservationDate, opt =>
                {
                    opt.MapFrom(src => src.ReservationDate);
                })
                .ForMember(dest => dest.Country, opt =>
                {
                    opt.MapFrom(src => src.Country);
                })
                .ForMember(dest => dest.City, opt =>
                {
                    opt.MapFrom(src => src.City);
                })
                .ForMember(dest => dest.Price, opt =>
                {
                    opt.MapFrom(src => src.Price);
                })
                .ForMember(dest => dest.Adress, opt =>
                {
                    opt.MapFrom(src => src.Adress);
                })
                .ForMember(dest => dest.Guid, opt =>
                {
                    opt.MapFrom(src => src.GUID);
                }).ReverseMap();
        }
    }
}
