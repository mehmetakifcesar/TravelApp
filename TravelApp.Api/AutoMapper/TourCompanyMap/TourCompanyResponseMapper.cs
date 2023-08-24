using AutoMapper;
using TravelApp.Entity.DTO.TourCompany;
using TravelApp.Entity.POCO;

namespace TravelApp.Api.AutoMapper.TourCompanyMap
{
    public class TourCompanyResponseMapper : Profile
    {
        public TourCompanyResponseMapper()
        {
            CreateMap<TourCompany, TourCompanyDTOResponse>()
                .ForMember(dest => dest.Name, opt =>
                {
                    opt.MapFrom(src => src.Name);
                })
                .ForMember(dest => dest.Adress, opt =>
                {
                    opt.MapFrom(src => src.Adress);
                })
                .ForMember(dest => dest.Email, opt =>
                {
                    opt.MapFrom(src => src.Email);
                })
                .ForMember(dest => dest.PhoneNumber, opt =>
                {
                    opt.MapFrom(src => src.PhoneNumber);
                })
                 .ForMember(dest => dest.Guid, opt =>
                 {
                     opt.MapFrom(src => src.GUID);
                 }).ReverseMap();
        }
    }
}
