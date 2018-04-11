using Agio.Flights.Business.Domain.Helpers;
using Agio.Flights.Business.Infrastructure.Abstract;
using Agio.Flights.DAL.DataModel.Entities;
using AutoMapper;

namespace Agio.Flights.Business.Infrastructure
{
    public sealed class MapperDomain : IMapperDomain
    {
        #region Attributes

        /// <summary>
        /// The mapper configuration
        /// </summary>
        private MapperConfiguration _config;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the current class
        /// </summary>
        public MapperDomain()
        {
            InitializeMapping();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Maps the specified object from TSource type in a new object of the TDestination type
        /// </summary>
        /// <typeparam name="TSource">The type of the source object</typeparam>
        /// <typeparam name="TDestination">The type of the destination object</typeparam>
        /// <param name="source">The source object to be mapped</param>
        /// <returns>
        /// Returns a new instance of the TDestination type object
        /// </returns>
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var mapper = _config.CreateMapper();

            return mapper.Map<TSource, TDestination>(source);
        }

        #endregion

        #region Private Methods

        private void InitializeMapping()
        {
            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTO.Aircraft, Aircraft>().ReverseMap();
                cfg.CreateMap<DTO.Airport, Airport>()
                    .ForMember(dst => dst.Latitude, opt => opt.MapFrom(src => src.Position.Latitude))
                    .ForMember(dst => dst.Longitude, opt => opt.MapFrom(src => src.Position.Longitude))
                    .ReverseMap()
                    .ForMember(dst => dst.Position, opt => opt.MapFrom(src => new Position
                    {
                        Latitude = src.Latitude,
                        Longitude = src.Longitude
                    }));
                cfg.CreateMap<DTO.Flight, Flight>()
                    .ForMember(dst => dst.AircraftId, opt => opt.MapFrom(src => src.Aircraft.Id))
                    .ForMember(dst => dst.DestinationAirportId, opt => opt.MapFrom(src => src.Destination.Id))
                    .ForMember(dst => dst.OriginAirportId, opt => opt.MapFrom(src => src.Origin.Id))
                    .ForMember(dst => dst.Aircraft, opt => opt.Ignore())
                    .ForMember(dst => dst.OriginAirport, opt => opt.Ignore())
                    .ForMember(dst => dst.DestinationAirport, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(dst => dst.Aircraft, opt => opt.MapFrom(src => new DTO.Aircraft
                    {
                        Id = src.AircraftId,
                        Model = src.Aircraft.Model,
                        TakeoffEffort = src.Aircraft.TakeoffEffort
                    }))
                    .ForMember(dst => dst.Destination, opt => opt.MapFrom(src => new DTO.Airport
                    {
                        Description = src.DestinationAirport.Description,
                        Iata = src.DestinationAirport.Iata,
                        Id = src.DestinationAirportId,
                        Position = new Position
                        {
                            Latitude = src.DestinationAirport.Latitude,
                            Longitude = src.DestinationAirport.Longitude
                        }
                    }))
                    .ForMember(dst => dst.Origin, opt => opt.MapFrom(src => new DTO.Airport
                    {
                        Description = src.OriginAirport.Description,
                        Iata = src.OriginAirport.Iata,
                        Id = src.OriginAirportId,
                        Position = new Position
                        {
                            Latitude = src.OriginAirport.Latitude,
                            Longitude = src.OriginAirport.Longitude
                        }
                    }));
            });
        }

        #endregion
    }
}
