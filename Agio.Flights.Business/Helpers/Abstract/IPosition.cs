namespace Agio.Flights.Business.Helpers.Abstract
{
    /// <summary>
    /// Describes the methods for a GPS Position management
    /// </summary>
    public interface IPosition
    {
        /// <summary>
        /// When implemented calculates the distance between the specified latitude and longitude coordinates and the current instance
        /// </summary>
        /// <param name="latitude">The latitude</param>
        /// <param name="longitude">The longitude</param>
        /// <returns>
        /// Returns the distance in meters
        /// </returns>
        double Distance(double latitude, double longitude);
    }
}
