using AutoMapper;
using TravelApp.Entity.DTO.Reservation;
using TravelApp.Entity.POCO;

namespace TravelApp.Api.AutoMapper.ReservationMap
{
    public class ReservationResponseMapper : Profile
    {
        public ReservationResponseMapper()
        {
            CreateMap<Reservation, ReservationDTOResponse>()
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
                })
                 .ForMember(dest => dest.Guid, opt =>
                 {
                     opt.MapFrom(src => src.GUID);
                 });

        }
    }
}
