using Agio.Flights.Business.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agio.Flights.Business.Services.Abstract
{
    /// <summary>
    /// Describes the airport service methods
    /// </summary>
    public interface IAirportService
    {
        /// <summary>
        /// When implemented inserts an airport into the database
        /// </summary>
        /// <param name="airport">The airport to to be created</param>
        Task Create(Airport airport);

        /// <summary>
        /// When implemented updates an airport into the database
        /// </summary>
        /// <param name="airport">The airport to update</param>
        Task Edit(Airport airport);

        /// <summary>
        /// When implemented deletes an airport from the database
        /// </summary>
        /// <param name="airport">The airport to delete</param>
        Task Destroy(Airport airport);

        /// <summary>
        /// When implemented returns all airports from the database
        /// </summary>
        Task<IEnumerable<Airport>> GetAll();

        /// <summary>
        /// When implemented reads an airport by id from the database
        /// </summary>
        /// <param name="id">The id of the airport</param>
        /// <returns>
        /// The airport that corresponds to the specified id
        /// </returns>
        Task<Airport> Read(int id);
    }
}
