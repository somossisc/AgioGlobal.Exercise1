using Agio.Flights.Business.Services.Abstract;
using Agio.Flights.Presentation.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Agio.Flights.Presentation.Controllers
{
    public class AircraftController : Controller
    {
        #region Attributes

        private readonly IAircraftService _service;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the current class with the specified parameters
        /// </summary>
        /// <param name="service">The service to access necessary data</param>
        public AircraftController(IAircraftService service)
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
            var model = await GetAircrafts();

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            var model = await GetAircraft(id);

            return View(model);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var model = await GetAircraft(id);

            return View(model);
        }

        #endregion

        #region POST Actions

        [HttpPost]
        public async Task<ActionResult> Create([Bind(Exclude = "Id")] AircraftViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var entity = Mapper.Map<Business.DTO.Aircraft>(model);

                await _service.Create(entity);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(AircraftViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var entity = Mapper.Map<Business.DTO.Aircraft>(model);

                await _service.Edit(entity);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, AircraftViewModel model)
        {
            var entity = await _service.Read(id);

            await _service.Destroy(entity);

            return RedirectToAction("Index");
        }

        #endregion

        #endregion

        #region Private Methods

        private async Task<AircraftViewModel> GetAircraft(int id)
        {
            var entity = await _service.Read(id);
            var result = Mapper.Map<AircraftViewModel>(entity);

            return result;
        }

        private async Task<IEnumerable<AircraftViewModel>> GetAircrafts()
        {
            var entities = await _service.GetAll();
            var result = Mapper.Map<IEnumerable<AircraftViewModel>>(entities);

            return result;
        }

        #endregion
    }
}
