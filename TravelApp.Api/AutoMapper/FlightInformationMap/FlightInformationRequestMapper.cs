﻿using AutoMapper;
using TravelApp.Entity.DTO.FlightInformation;
using TravelApp.Entity.POCO;

namespace TravelApp.Api.AutoMapper.FlightInformationMap
{
    public class FlightInformationRequestMapper : Profile
    {
        public FlightInformationRequestMapper()
        {
            CreateMap<FlightInformation, FlightInformationDTORequest>()
                .ForMember(dest => dest.Airline, opt =>
                {
                    opt.MapFrom(src => src.Airline);
                })
                .ForMember(dest => dest.DepartureDate, opt =>
                {
                    opt.MapFrom(src => src.DepartureDate);
                })
                .ForMember(dest => dest.ArrivalDate, opt =>
                {
                    opt.MapFrom(src => src.ArrivalDate);
                })
                .ForMember(dest => dest.Origin, opt =>
                {
                    opt.MapFrom(src => src.Origin);
                })
                .ForMember(dest => dest.Destination, opt =>
                {
                    opt.MapFrom(src => src.Destination);
                })
                .ForMember(dest => dest.Price, opt =>
                {
                    opt.MapFrom(src => src.Price);
                }).ReverseMap();

        }
    }
}
