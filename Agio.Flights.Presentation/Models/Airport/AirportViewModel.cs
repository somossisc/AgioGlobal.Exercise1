using Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Agio.Flights.Presentation.Models.Airport
{
    public sealed class AirportViewModel
    {
        #region Properties

        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "IATARequired", ErrorMessageResourceType = typeof(PresentationResource))]
        [MaxLength(3, ErrorMessageResourceName = "IATAMaxLength", ErrorMessageResourceType = typeof(PresentationResource))]
        [DisplayName("IATA")]
        public string Iata { get; set; }

        [Required(ErrorMessageResourceName = "LatitudeRequired", ErrorMessageResourceType = typeof(PresentationResource))]
        public double Latitude { get; set; }

        [Required(ErrorMessageResourceName = "LongitudeRequired", ErrorMessageResourceType = typeof(PresentationResource))]
        public double Longitude { get; set; }

        public string Description { get; set; }

        #endregion
    }
}