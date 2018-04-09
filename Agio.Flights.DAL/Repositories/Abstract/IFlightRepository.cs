using Agio.Flights.DAL.DataModel.Entities;

namespace Agio.Flights.DAL.DataModel.Repositories.Abstract
{
    /// <summary>
    /// Describes the necessary methods to be implemented by an Flight Repository
    /// </summary>
    public interface IFlightRepository : IReader<Flight>, IWriter<Flight>
    {
    }
}
