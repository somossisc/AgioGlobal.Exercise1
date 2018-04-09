using Agio.Flights.DAL.DataModel.Entities;

namespace Agio.Flights.DAL.DataModel.Repositories.Abstract
{
    /// <summary>
    /// Describes the necessary methods to be implemented by an Aircraft Repository
    /// </summary>
    public interface IAircraftRepository : IReader<Aircraft>, IWriter<Aircraft>
    {
    }
}
