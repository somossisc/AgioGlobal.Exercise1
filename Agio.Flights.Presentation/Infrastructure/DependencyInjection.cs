using Agio.Flights.Business.Infrastructure;
using Agio.Flights.Business.Infrastructure.Abstract;
using Agio.Flights.Business.Services;
using Agio.Flights.Business.Services.Abstract;
using Agio.Flights.DAL.DataModel.Entities;
using Agio.Flights.DAL.DataModel.Repositories;
using Agio.Flights.DAL.DataModel.Repositories.Abstract;
using Agio.Flights.Presentation.Controllers;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;

namespace Agio.Flights.Presentation.Infrastructure
{
    public static class DependencyInjection
    {
        #region Public Methods

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            //Register DAL and Business objects
            builder.Register(itm => new FlightsContainer()).InstancePerLifetimeScope();
            builder.RegisterType<AircraftRepository>().As<IAircraftRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AirportRepository>().As<IAirportRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FlightRepository>().As<IFlightRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MapperDomain>().As<IMapperDomain>();
            builder.RegisterType<AircraftService>().As<IAircraftService>();
            builder.RegisterType<AirportService>().As<IAirportService>();
            builder.RegisterType<FlightService>().As<IFlightService>();

            //Register controllers
            builder.RegisterType<HomeController>().InstancePerRequest();
            builder.RegisterType<AirportController>().InstancePerRequest();

            // MVC - Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        #endregion
    }
}