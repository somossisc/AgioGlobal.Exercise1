using System.Threading.Tasks;

namespace Agio.Flights.DAL.DataModel.Repositories.Abstract
{
    /// <summary>
    /// Describes the methods to write into database
    /// </summary>
    /// <typeparam name="T">The type of the entity to be written</typeparam>
    public interface IWriter<T> where T : class
    {
        /// <summary>
        /// When implemented inserts the entity to the database
        /// </summary>
        /// <param name="entity">The entity to insert</param>
        Task Insert(T entity);

        /// <summary>
        /// When implemented updates changes to the database
        /// </summary>
        /// <param name="entity">The entity to update</param>
        Task Update(T entity);

        /// <summary>
        /// When implemented deletes the entity from the database
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        Task Delete(T entity);
    }
}
