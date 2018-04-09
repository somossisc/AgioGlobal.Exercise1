using Agio.Flights.Business.Helpers.Abstract;
using System;

namespace Agio.Flights.Business.Domain.Helpers
{
    /// <summary>
    /// Implemnts a GPS Position
    /// </summary>
    public class Position : IPosition
    {
        #region Properties

        /// <summary>
        /// Gets or sets the latitude of the current instance
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the current instance
        /// </summary>
        public double Longitude { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// When implemented calculates the distance between the specified latitude and longitude coordinates and the current instance
        /// </summary>
        /// <param name="latitude">The latitude</param>
        /// <param name="longitude">The longitude</param>
        /// <returns>
        /// Returns the distance in meters
        /// </returns>
        public double Distance(double latitude, double longitude)
        {
            var baseRad = Math.PI * Latitude / 180;
            var targetRad = Math.PI * latitude / 180;
            var theta = Longitude - longitude;
            var thetaRad = Math.PI * theta / 180;

            var result = Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
                         Math.Cos(targetRad) * Math.Cos(thetaRad);

            result = Math.Acos(result);

            result = result * 180 / Math.PI;
            result = result * 60 * 1.609344; // Convert to Kilometers
            result = result * 1000D; // Convert to meters

            return result;
        }

        #endregion
    }
}
