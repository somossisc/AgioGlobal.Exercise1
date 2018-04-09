namespace Agio.Flights.Business.DTO
{
    /// <summary>
    /// Implements an aircraft data transfer object
    /// </summary>
    public sealed class Aircraft
    {
        #region Properties

        /// <summary>
        /// Gets or sets of the id of the current instance
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the model of the current instance
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the takeoff effort of the current instance
        /// </summary>
        public double TakeoffEffort { get; set; }

        #endregion
    }
}
