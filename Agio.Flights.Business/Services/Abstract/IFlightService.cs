using Agio.Flights.Business.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agio.Flights.Business.Services.Abstract
{
    /// <summary>
    /// Describes the flight service methods
    /// </summary>
    public interface IFlightService
    {
        /// <summary>
        /// When implemented insert the specified flight into the database
        /// </summary>
        /// <param name="flight">The flight to be created</param>
        Task Create(Flight flight);

        /// <summary>
        /// When implemented calculates the fuel need by the especified flight
        /// </summary>
        /// <param name="flight">The flight to calculate its needed fuel</param>
        void CalculateFuel(Flight flight);

        /// <summary>
        /// When implemented returns all flights from database
        /// </summary>
        Task<IEnumerable<Flight>> GetAll();

        /// <summary>
        /// When implemented reads a flight by id from the database
        /// </summary>
        /// <param name="id">The id of the flight</param>
        /// <returns>
        /// The flight that corresponds to the specified id
        /// </returns>
        Task<Flight> Read(int id);
    }
}
