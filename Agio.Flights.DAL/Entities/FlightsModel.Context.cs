﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FlightsContainer : DbContext
    {
        public FlightsContainer()
            : base("name=FlightsContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<Aircraft> Aircraft { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
    }
}
