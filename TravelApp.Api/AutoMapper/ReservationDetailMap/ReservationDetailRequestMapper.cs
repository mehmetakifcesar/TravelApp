using AutoMapper;
using TravelApp.Entity.DTO.ReservationDetail;
using TravelApp.Entity.POCO;

namespace TravelApp.Api.AutoMapper.ReservationDetailMap
{
    public class ReservationDetailRequestMapper : Profile
    {
        public ReservationDetailRequestMapper()
        {
            CreateMap<ReservationDetail, ReservationDetailDTORequest>()
                .ForMember(dest => dest.ReservationID, opt =>
                {
                    opt.MapFrom(src => src.ReservationID);
                })
                .ForMember(dest => dest.DateTime, opt =>
                {
                    opt.MapFrom(src => src.DateTime);
                })
                .ForMember(dest => dest.TotalPrice, opt =>
                {
                    opt.MapFrom(src => src.TotalPrice);
                }).ReverseMap();


        }
    }
}
