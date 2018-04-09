using Agio.Flights.Business.Infrastructure.Abstract;
using Agio.Flights.Business.Services.Abstract;
using Agio.Flights.DAL.DataModel.Entities;
using Agio.Flights.DAL.DataModel.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agio.Flights.Business.Services
{
    public sealed class FlightService : BaseService, IFlightService
    {
        #region Attributes

        /// <summary>
        /// The repository to access database
        /// </summary>
        private readonly IFlightRepository _repository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the current class with the specified parameters
        /// </summary>
        /// <param name="mapper">The mapper of the service</param>
        /// <param name="repository">The repository to access database</param>
        public FlightService(IMapperDomain mapper, IFlightRepository repository)
            : base(mapper)
        {
            _repository = repository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Calculates the fuel need by the especified flight
        /// </summary>
        /// <param name="flight">The flight to calculate its needed fuel</param>
        public void CalculateFuel(DTO.Flight flight)
        {
            var distance = flight.Origin.Position.Distance(flight.Destination.Position.Latitude, flight.Destination.Position.Longitude);
            var result = (distance / flight.Time.TotalHours) + flight.Aircraft.TakeoffEffort;

            flight.FuelNeeded = result;
        }

        /// <summary>
        /// Creates a new flight into the database
        /// </summary>
        /// <param name="airport">The airport to to be created</param>
        public async Task Create(DTO.Flight flight)
        {
            var entity = _mapper.Map<DTO.Flight, Flight>(flight);

            await _repository.Insert(entity);

            flight.Id = entity.Id;
        }

        /// <summary>
        /// Returns all flights from the database
        /// </summary>
        public async Task<IEnumerable<DTO.Flight>> GetAll()
        {
            var entities = (from itm in await _repository.List()
                            orderby itm.Time ascending //Default ordering
                            select itm).ToList();
            var result = _mapper.Map<IEnumerable<Flight>, IEnumerable<DTO.Flight>>(entities);

            return result;
        }

        /// <summary>
        /// Reads an flight by id from the database
        /// </summary>
        /// <param name="id">The id of the flight</param>
        /// <returns>
        /// The flight that corresponds to the specified id
        /// </returns>
        public async Task<DTO.Flight> Read(int id)
        {
            var entity = await _repository.Read(id);
            var result = _mapper.Map<Flight, DTO.Flight>(entity);

            return result;
        }

        #endregion
    }
}
