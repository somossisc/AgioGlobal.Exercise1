//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Agio.Flights.DAL.DataModel.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Flight
    {
        public int Id { get; set; }
        public int OriginAirportId { get; set; }
        public int DestinationAirportId { get; set; }
        public int AircraftId { get; set; }
        public System.TimeSpan Time { get; set; }
    
        public virtual Airport OriginAirport { get; set; }
        public virtual Airport DestinationAirport { get; set; }
        public virtual Aircraft Aircraft { get; set; }
    }
}
