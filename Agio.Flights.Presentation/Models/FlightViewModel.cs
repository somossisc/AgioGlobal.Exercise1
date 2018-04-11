using System;
using System.ComponentModel.DataAnnotations;

namespace Agio.Flights.Presentation.Models
{
    /// <summary>
    /// Implements a view model for a flight
    /// </summary>
    public sealed class FlightViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id of the current instance
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the aircraft id of the current instance
        /// </summary>
        [Display(Name = "Aircraft")]
        public int AircraftId { get; set; }

        /// <summary>
        /// Gets or sets the aircraft model of the current instance
        /// </summary>
        public string Aircraft { get; set; }

        /// <summary>
        /// Gets or sets the destination airport id of the current instance
        /// </summary>
        [Display(Name = "Destination")]
        public int DestinationAirportId { get; set; }

        /// <summary>
        /// Gets or sets the destination ariport IATA of the current instance
        /// </summary>
        [Display(Name = "Destination")]
        public string DestinationAirport { get; set; }

        /// <summary>
        /// Gets or sets the duration of the current instance
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Gets or sets the origin airport id of the current instance
        /// </summary>
        [Display(Name = "Origin")]
        public int OriginAirportId { get; set; }

        /// <summary>
        /// Gets or sets the origin airport IATA of the current instance
        /// </summary>
        [Display(Name = "Origin")]
        public string OriginAirport { get; set; }

        /// <summary>
        /// Gets or sets the fuel needed of the current instance
        /// </summary>
        [Display(Name = "Fuel Needed")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double? FuelNeeded { get; set; }

        #endregion
    }
}