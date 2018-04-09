using Agio.Flights.DAL.DataModel.Entities;
using Agio.Flights.DAL.DataModel.Repositories.Abstract;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Agio.Flights.DAL.DataModel.Repositories
{
    /// <summary>
    /// Implements the aircraft table repository
    /// </summary>
    public class AircraftRepository : IAircraftRepository
    {
        #region Attributes

        /// <summary>
        /// The database context
        /// </summary>
        private readonly FlightsContainer _dbContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the current class with the specified parameters
        /// </summary>
        /// <param name="container">The database context</param>
        public AircraftRepository(FlightsContainer container)
        {
            _dbContext = container;
        }

        #endregion

        #region Public Methods

        #region Members of IAircraftRepository

        public async Task Delete(Aircraft entity)
        {
            _dbContext.Aircraft.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Insert(Aircraft entity)
        {
            _dbContext.Aircraft.Add(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Aircraft>> List()
        {
            return await _dbContext.Aircraft.ToListAsync();
        }

        public async Task<Aircraft> Read(int id)
        {
            var result = await  (from air in _dbContext.Aircraft
                                 where air.Id == id
                                 select air).SingleOrDefaultAsync();

            return result;
        }

        public async Task Update(Aircraft entity)
        {
            await _dbContext.SaveChangesAsync();
        }

        #endregion

        #endregion
    }
}
