using Agio.Flights.Business.Infrastructure.Abstract;
using Agio.Flights.Business.Services.Abstract;
using Agio.Flights.DAL.DataModel.Entities;
using Agio.Flights.DAL.DataModel.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agio.Flights.Business.Services
{
    public sealed class AircraftService : BaseService, IAircraftService
    {
        #region Attributes

        /// <summary>
        /// The repository to access database
        /// </summary>
        private readonly IAircraftRepository _repository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the current class with the specified parameters
        /// </summary>
        /// <param name="mapper">The mapper of the service</param>
        /// <param name="repository">The repository to access database</param>
        public AircraftService(IMapperDomain mapper, IAircraftRepository repository)
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
        public async Task Create(DTO.Aircraft aircraft)
        {
            var entity = _mapper.Map<DTO.Aircraft, Aircraft>(aircraft);

            await _repository.Insert(entity);

            aircraft.Id = entity.Id;
        }

        /// <summary>
        /// Destroy an aircraft from the database
        /// </summary>
        /// <param name="aircraft">The aircraft to delete</param>
        public async Task Destroy(DTO.Aircraft aircraft)
        {
            var entity = await _repository.Read(aircraft.Id);

            await _repository.Delete(entity);
        }

        /// <summary>
        /// Updates an airport into the database
        /// </summary>
        /// <param name="airport">The airport to to be created</param>
        public async Task Edit(DTO.Aircraft aircraft)
        {
            var entity = await _repository.Read(aircraft.Id);

            entity.Model = aircraft.Model;
            entity.TakeoffEffort = aircraft.TakeoffEffort;

            await _repository.Update(entity);
        }

        /// <summary>
        /// Returns all aircrafts from the database
        /// </summary>
        public async Task<IEnumerable<DTO.Aircraft>> GetAll()
        {
            var result = (from itm in await _repository.List()
                          orderby itm.Model ascending //Default ordering
                          select itm).ToList();

            return _mapper.Map<IEnumerable<Aircraft>, IEnumerable<DTO.Aircraft>>(result);
        }

        /// <summary>
        /// Reads an aircraft by id from the database
        /// </summary>
        /// <param name="id">The id of the aircraft</param>
        /// <returns>
        /// The aircraft that corresponds to the specified id
        /// </returns>
        public async Task<DTO.Aircraft> Read(int id)
        {
            var entity = await _repository.Read(id);
            var result = _mapper.Map<Aircraft, DTO.Aircraft>(entity);

            return result;
        }

        #endregion
    }
}
