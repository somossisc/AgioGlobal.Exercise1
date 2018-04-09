using Agio.Flights.Business.Domain.Helpers;
using Agio.Flights.Presentation.Models.Airport;
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
            });
        }

        #endregion
    }
}