using Agio.Flights.Business.Domain.Helpers;
using Agio.Flights.Presentation.Models;
using AutoMapper;

namespace Agio.Flights.Presentation.Infrastructure
{
    public static class Mapping
    {
        #region Public Methods

        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Business.DTO.Airport, AirportViewModel>()
                    .ForMember(dst => dst.Latitude, opt => opt.MapFrom(src => src.Position.Latitude))
                    .ForMember(dst => dst.Longitude, opt => opt.MapFrom(src => src.Position.Longitude))
                    .ReverseMap()
                    .ForMember(dst => dst.Position, opt => opt.MapFrom(src => new Position { Latitude = src.Latitude, Longitude = src.Longitude }));
                cfg.CreateMap<Business.DTO.Aircraft, AircraftViewModel>()
                    .ForMember(dst => dst.ModelName, opt => opt.MapFrom(src => src.Model))
                    .ReverseMap()
                    .ForMember(dst => dst.Model, opt => opt.MapFrom(src => src.ModelName));
                cfg.CreateMap<Business.DTO.Flight, FlightViewModel>()
                    .ForMember(dst => dst.Aircraft, opt => opt.MapFrom(src => src.Aircraft.Model))
                    .ForMember(dst => dst.AircraftId, opt => opt.MapFrom(src => src.Aircraft.Id))
                    .ForMember(dst => dst.DestinationAirport, opt => opt.MapFrom(src => src.Destination.Iata))
                    .ForMember(dst => dst.DestinationAirportId, opt => opt.MapFrom(src => src.Destination.Id))
                    .ForMember(dst => dst.OriginAirport, opt => opt.MapFrom(src => src.Origin.Iata))
                    .ForMember(dst => dst.OriginAirportId, opt => opt.MapFrom(src => src.Origin.Id))
                    .ForMember(dst => dst.Duration, opt => opt.MapFrom(src => src.Time))
                    .ReverseMap()
                    .ForMember(dst => dst.Aircraft, opt => opt.MapFrom(src => new Business.DTO.Aircraft { Id = src.AircraftId }))
                    .ForMember(dst => dst.Destination, opt => opt.MapFrom(src => new Business.DTO.Airport { Id = src.DestinationAirportId }))
                    .ForMember(dst => dst.Origin, opt => opt.MapFrom(src => new Business.DTO.Airport { Id = src.OriginAirportId }))
                    .ForMember(dst => dst.Time, opt => opt.MapFrom(src => src.Duration));
            });
        }

        #endregion
    }
}