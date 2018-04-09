using Agio.Flights.DAL.DataModel.Entities;

namespace Agio.Flights.DAL.DataModel.Repositories.Abstract
{
    /// <summary>
    /// Describes the necessary methods to be implemented by an Airport Repository
    /// </summary>
    public interface IAirportRepository : IReader<Airport>, IWriter<Airport>
    {
    }
}
