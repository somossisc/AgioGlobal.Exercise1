using Agio.Flights.DAL.DataModel.Entities;
using Agio.Flights.DAL.DataModel.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Agio.Flights.DAL.DataModel.Repositories
{
    /// <summary>
    /// Implements the airport table repository
    /// </summary>
    public class AirportRepository : IAirportRepository, IDisposable
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
        public AirportRepository(FlightsContainer container)
        {
            _dbContext = container;
        }

        #endregion

        #region Public Methods

        #region Members of IAirportRepository

        public async Task Delete(Airport entity)
        {
            _dbContext.Airports.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Insert(Airport entity)
        {
            _dbContext.Airports.Add(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Airport>> List()
        {
            return await _dbContext.Airports.ToListAsync();
        }

        public async Task<Airport> Read(int id)
        {
            var result = await (from air in _dbContext.Airports
                                where air.Id == id
                                select air).SingleOrDefaultAsync();

            return result;
        }

        public async Task Update(Airport entity)
        {
            await _dbContext.SaveChangesAsync();
        }

        #endregion

        #region Members of IDisposable

        /// <summary>
        /// Free up the resources of the current instance
        /// </summary>
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        #endregion

        #endregion
    }
}
