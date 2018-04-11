using Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Agio.Flights.Presentation.Models
{
    /// <summary>
    /// Implements a view model for an Airport
    /// </summary>
    public sealed class AirportViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id of the current instance
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the IATA code of the current instance
        /// </summary>
        [Required(ErrorMessageResourceName = "IATARequired", ErrorMessageResourceType = typeof(PresentationResource))]
        [MaxLength(3, ErrorMessageResourceName = "IATAMaxLength", ErrorMessageResourceType = typeof(PresentationResource))]
        [DisplayName("IATA")]
        public string Iata { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the current instance
        /// </summary>
        [Required(ErrorMessageResourceName = "LatitudeRequired", ErrorMessageResourceType = typeof(PresentationResource))]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the current instance
        /// </summary>
        [Required(ErrorMessageResourceName = "LongitudeRequired", ErrorMessageResourceType = typeof(PresentationResource))]
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the descripion of the current instance
        /// </summary>
        public string Description { get; set; }

        #endregion
    }
}