using System;

namespace Agio.Flights.Business.DTO
{
    /// <summary>
    /// Implements a flight data transfer object
    /// </summary>
    public sealed class Flight
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id of the current instance
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the aircraft of the current instance
        /// </summary>
        public Aircraft Aircraft { get; set; }

        /// <summary>
        /// Gets or sets the origin of the current instance
        /// </summary>
        public Airport Origin { get; set; }

        /// <summary>
        /// Gets or sets the destination of the current instance
        /// </summary>
        public Airport Destination { get; set; }

        /// <summary>
        /// Gets or sets the time of the current instance
        /// </summary>
        public TimeSpan Time { get; set; }

        /// <summary>
        /// Gets or sets the fuel needed of the current instance
        /// </summary>
        public double FuelNeeded { get; set; }

        #endregion
    }
}
