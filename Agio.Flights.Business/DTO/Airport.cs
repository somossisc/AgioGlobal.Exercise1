using Agio.Flights.Business.Domain.Helpers;

namespace Agio.Flights.Business.DTO
{
    /// <summary>
    /// Implements an airport data transfer object
    /// </summary>
    public sealed class Airport
    {
        #region Attributes

        /// <summary>
        /// Gets or sets the Id of the current instance
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the IATA code of the current instance
        /// </summary>
        public string Iata { get; set; }

        /// <summary>
        /// Gets or sets the GPS position of the current instance
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Gets or sets the description of the current instance
        /// </summary>
        public string Description { get; set; }

        #endregion
    }
}
