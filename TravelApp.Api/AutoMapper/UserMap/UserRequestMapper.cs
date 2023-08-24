using AutoMapper;
using TravelApp.Entity.DTO.UserDTO;
using TravelApp.Entity.POCO;

namespace TravelApp.Api.AutoMapper.UserMap
{
    public class UserRequestMapper : Profile
    {
        public UserRequestMapper()
        {
            CreateMap<User,UserDTORequest>()
                .ForMember(dest => dest.FirstName, opt =>
                {
                    opt.MapFrom(src => src.FirstName);
                })
                .ForMember(dest => dest.LastName, opt =>
                {
                    opt.MapFrom(src => src.LastName);
                })
                .ForMember(dest => dest.Username, opt =>
                {
                    opt.MapFrom(src => src.Username);
                })
                .ForMember(dest => dest.Password, opt =>
                {
                    opt.MapFrom(src => src.Password);
                })
                .ForMember(dest => dest.PhoneNumber, opt =>
                {
                    opt.MapFrom(src => src.PhoneNumber);
                })
                .ForMember(dest => dest.Email, opt =>
                {
                    opt.MapFrom(src => src.Email);
                })
                .ForMember(dest => dest.Adress, opt =>
                {
                    opt.MapFrom(src => src.Adress);
                }).ReverseMap();

        }
    }
}
