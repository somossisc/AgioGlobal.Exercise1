using Agio.Flights.Business.Infrastructure.Abstract;
using Agio.Flights.Business.Services.Abstract;
using Agio.Flights.DAL.DataModel.Entities;
using Agio.Flights.DAL.DataModel.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agio.Flights.Business.Services
{
    public sealed class AirportService : BaseService, IAirportService
    {
        #region Attributes

        /// <summary>
        /// The repository to access database
        /// </summary>
        private readonly IAirportRepository _repository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the current class with the specified parameters
        /// </summary>
        /// <param name="mapper">The mapper of the service</param>
        /// <param name="repository">The repository to access database</param>
        public AirportService(IMapperDomain mapper, IAirportRepository repository)
            : base(mapper)
        {
            _repository = repository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new airport into the database
        /// </summary>
        /// <param name="airport">The airport to to be created</param>
        public async Task Create(DTO.Airport airport)
        {
            var entity = _mapper.Map<DTO.Airport, Airport>(airport);

            await _repository.Insert(entity);

            airport.Id = entity.Id;
        }

        /// <summary>
        /// Destroy an airport from the database
        /// </summary>
        /// <param name="aircraft">The airport to delete</param>
        public async Task Destroy(DTO.Airport airport)
        {
            var entity = await _repository.Read(airport.Id);

            await _repository.Delete(entity);
        }

        /// <summary>
        /// Updates an airport into the database
        /// </summary>
        /// <param name="airport">The airport to to be created</param>
        public async Task Edit(DTO.Airport airport)
        {
            var entity = await _repository.Read(airport.Id);

            entity.Iata = airport.Iata;
            entity.Latitude = airport.Position.Latitude;
            entity.Longitude = airport.Position.Longitude;
            entity.Description = airport.Description;

            await _repository.Update(entity);
        }

        /// <summary>
        /// Returns all airports from the database
        /// </summary>
        public async Task<IEnumerable<DTO.Airport>> GetAll()
        {
            var entities = (from itm in await _repository.List()
                            orderby itm.Iata ascending //Default ordering
                            select itm).ToList();
            var result = _mapper.Map<IEnumerable<Airport>, IEnumerable<DTO.Airport>>(entities);

            return result;
        }

        /// <summary>
        /// Reads an airport by id from the database
        /// </summary>
        /// <param name="id">The id of the airport</param>
        /// <returns>
        /// The airport that corresponds to the specified id
        /// </returns>
        public async Task<DTO.Airport> Read(int id)
        {
            var entity = await _repository.Read(id);
            var result = _mapper.Map<Airport, DTO.Airport>(entity);

            return result;
        }

        #endregion
    }
}
