using Agio.Flights.Business.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agio.Flights.Business.Services.Abstract
{
    /// <summary>
    /// Describes the aircraft service methods
    /// </summary>
    public interface IAircraftService
    {
        /// <summary>
        /// When implemented inserts an aircraft into the database
        /// </summary>
        /// <param name="aircraft">The aircraft to be created</param>
        Task Create(Aircraft aircraft);

        /// <summary>
        /// When implemented updates an aircraft into the database
        /// </summary>
        /// <param name="aircraft">The aircraft to update</param>
        Task Edit(Aircraft aircraft);

        /// <summary>
        /// When implemented deletes an aircraft from the database
        /// </summary>
        /// <param name="aircraft">The aircraft to delete</param>
        Task Destroy(Aircraft aircraft);

        /// <summary>
        /// When implemented returns all aircrafts from the database
        /// </summary>
        Task<IEnumerable<Aircraft>> GetAll();

        /// <summary>
        /// When implemented reads an aircraft by id from the database
        /// </summary>
        /// <param name="id">The id of the aircraft</param>
        /// <returns>
        /// The aircraft that corresponds to the specified id
        /// </returns>
        Task<Aircraft> Read(int id);
    }
}
