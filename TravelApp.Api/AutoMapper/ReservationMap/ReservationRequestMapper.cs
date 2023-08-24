using AutoMapper;
using TravelApp.Entity.DTO.Reservation;
using TravelApp.Entity.POCO;

namespace TravelApp.Api.AutoMapper.ReservationMap
{
    public class ReservationRequestMapper : Profile
    {
        public ReservationRequestMapper()
        {
            CreateMap<Reservation, ReservationDTORequest>()
                .ForMember(dest => dest.ReservationDate, opt =>
                {
                    opt.MapFrom(src => src.ReservationDate);
                })
                .ForMember(dest => dest.NumberOfTravelers, opt =>
                {
                    opt.MapFrom(src => src.NumberOfTravelers);
                })
                .ForMember(dest => dest.UserID, opt =>
                {
                    opt.MapFrom(src => src.UserID);
                })
                .ForMember(dest => dest.Price, opt =>
                {
                    opt.MapFrom(src => src.Price);
                }).ReverseMap();

        }
    }
}
