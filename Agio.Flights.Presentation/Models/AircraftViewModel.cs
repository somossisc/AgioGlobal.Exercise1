using Resources;
using System.ComponentModel.DataAnnotations;

namespace Agio.Flights.Presentation.Models
{
    /// <summary>
    /// Implements a view model for an aircraft
    /// </summary>
    public sealed class AircraftViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id of the current instance
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the model of the current instance
        /// </summary>
        [Required(ErrorMessageResourceName = "ModelRequired", ErrorMessageResourceType = typeof(PresentationResource))]
        [Display(Name = "Model")]
        public string ModelName { get; set; }

        /// <summary>
        /// Gets or sets the takeoff effort of the current instance
        /// </summary>
        [Required(ErrorMessageResourceName = "TakeOffEffortRequired", ErrorMessageResourceType = typeof(PresentationResource))]
        [Display(Name = "Takeoff Effort")]
        public double TakeoffEffort { get; set; }

        #endregion
    }
}