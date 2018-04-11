using Agio.Flights.Business.Services.Abstract;
using Agio.Flights.Presentation.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Agio.Flights.Presentation.Controllers
{
    public class FlightController : Controller
    {
        #region Attributes

        private readonly IFlightService _flightService;

        private readonly IAircraftService _aircraftService;

        private readonly IAirportService _airportService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the current class with the specified parameters
        /// </summary>
        /// <param name="aircraftService">The service to access necessary data of aircraft table</param>
        /// <param name="airportService">The service to access necessary data of airport table</param>
        /// <param name="flightService">The service to access necessary data of flight table</param>
        public FlightController(IFlightService flightService, IAircraftService aircraftService, IAirportService airportService)
            : base()
        {
            _aircraftService = aircraftService;
            _airportService = airportService;
            _flightService = flightService;
        }

        #endregion

        #region Public Methods

        #region GET Actions

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = await GetFlights();

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            await InitViewData();

            return View();
        }

        #endregion

        #region POST Actions

        public async Task<ActionResult> Create([Bind(Exclude = "Id, Aircraft, Destination, FuelNeeded, Origin")] FlightViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var entity = Mapper.Map<Business.DTO.Flight>(model);

                await _flightService.Create(entity);
            }

            return RedirectToAction("Index");
        }

        #endregion

        #endregion

        #region Private Methods

        private async Task<IEnumerable<FlightViewModel>> GetFlights()
        {
            var entities = await _flightService.GetAll();
            var result = Mapper.Map<IEnumerable<FlightViewModel>>(entities);

            return result;
        }

        private async Task InitViewData()
        {
            ViewData["Aircrafts"] = (from itm in await _aircraftService.GetAll()
                                     select new SelectListItem
                                     {
                                         Text = itm.Model,
                                         Value = itm.Id.ToString()
                                     }).ToList();
            ViewData["Airports"] = (from itm in await _airportService.GetAll()
                                     select new SelectListItem
                                     {
                                         Text = itm.Iata,
                                         Value = itm.Id.ToString()
                                     }).ToList();
        }

        #endregion
    }
}