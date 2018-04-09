using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agio.Flights.DAL.DataModel.Repositories.Abstract
{
    public interface IReader<T> where T : class
    {
        Task<IEnumerable<T>> List();

        Task<T> Read(int id);
    }
}
