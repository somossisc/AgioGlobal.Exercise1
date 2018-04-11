using Agio.Flights.Business.Helpers.Abstract;
using System;

namespace Agio.Flights.Business.Domain.Helpers
{
    /// <summary>
    /// Implemnts a GPS Position
    /// </summary>
    public class Position : IPosition
    {
        #region Constants

        /// <summary>
        /// The earth radio distance in kilometers
        /// </summary>
        public const double EARTH_RADIO = 6372.8;

        #endregion

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
        /// Returns the distance in kilometers
        /// </returns>
        /// <remarks>
        /// Based on the <seealso cref="https://en.wikipedia.org/wiki/Haversine_formula">Harvesine Formula</seealso>
        /// </remarks>
        public double Distance(double latitude, double longitude)
        {
            //Calculate distances between origin and destinations latitudes and logitudes
            var latDis = ToRadians(Latitude - latitude);
            var lonDis = ToRadians(Longitude - longitude);

            //Convert current Latitudes to Radians
            var latOri = ToRadians(Latitude);
            var latDes = ToRadians(latitude);

            var a = Math.Sin(latDis / 2.0) * Math.Sin(latDis / 2.0) + Math.Sin(lonDis / 2.0) * Math.Sin(lonDis / 2.0) * Math.Cos(latOri) * Math.Cos(latDes);
            var c = 2.0 * Math.Asin(Math.Sqrt(a));

            var result = EARTH_RADIO * 2.0 * Math.Asin(Math.Sqrt(a));

            return result;
        }

        /// <summary>
        /// Converts an angle to radians
        /// </summary>
        /// <param name="angle">The angle to convert</param>
        public static double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        #endregion
    }
}
