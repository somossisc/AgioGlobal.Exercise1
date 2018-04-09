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
    /// Implements the flight table repository
    /// </summary>
    public class FlightRepository : IFlightRepository
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
        public FlightRepository(FlightsContainer container)
        {
            _dbContext = container;
        }

        #endregion

        #region Public Methods

        #region Members of IAirportRepository

        public async Task Delete(Flight entity)
        {
            _dbContext.Flights.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Insert(Flight entity)
        {
            _dbContext.Flights.Add(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Flight>> List()
        {
            return await _dbContext.Flights.ToListAsync();
        }

        public async Task<Flight> Read(int id)
        {
            var result = await (from fli in _dbContext.Flights
                                where fli.Id == id
                                select fli).SingleOrDefaultAsync();

            return result;
        }

        public async Task Update(Flight entity)
        {
            await _dbContext.SaveChangesAsync();
        }

        #endregion

        #endregion
    }
}
