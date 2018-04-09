using Agio.Flights.Business.Services.Abstract;
using Agio.Flights.Presentation.Models.Airport;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Agio.Flights.Presentation.Controllers
{
    public class AirportController : Controller
    {
        #region Attributes

        private readonly IAirportService _service;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the current class with the specified parameters
        /// </summary>
        /// <param name="service">The service to access necessary data</param>
        public AirportController(IAirportService service)
            : base()
        {
            _service = service;
        }

        #endregion

        #region Public Methods

        #region GET Actions

        // GET: Airport
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = await GetAirports();

            return View(model);
        }

        // GET: Airport/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // GET: Airport/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await GetAirport(id);

            return View(model);
        }

        // GET: Airport/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await GetAirport(id);

            return View(model);
        }

        #endregion

        #region POST Actions

        // POST: Airport/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Exclude = "Id")] AirportViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var entity = Mapper.Map<Business.DTO.Airport>(model);

                await _service.Create(entity);
            }

            return RedirectToAction("Index");
        }

        // POST: Airport/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(AirportViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var entity = Mapper.Map<Business.DTO.Airport>(model);

                await _service.Edit(entity);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, AirportViewModel model)
        {
            var entity = await _service.Read(id);

            await _service.Destroy(entity);

            return RedirectToAction("Index");
        }

        #endregion

        #endregion

        #region Private Methods

        private async Task<AirportViewModel> GetAirport(int id)
        {
            var entity = await _service.Read(id);
            var result = Mapper.Map<AirportViewModel>(entity);

            return result;
        }

        private async Task<IEnumerable<AirportViewModel>> GetAirports()
        {
            var entities = await _service.GetAll();
            var result = Mapper.Map<IEnumerable<AirportViewModel>>(entities);

            return result;
        }

        #endregion
    }
}
