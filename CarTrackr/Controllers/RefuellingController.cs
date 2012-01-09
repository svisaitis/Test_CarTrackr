using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using CarTrackr.Repository;
using CarTrackr.Data;
using CarTrackr.Extensions;
using CarTrackr.Domain;
using CarTrackr.Models;
using CarTrackr.Core;
using System.Data.Linq;
using System.Globalization;

namespace CarTrackr.Controllers
{
    [Authorize]
    public class RefuellingController : Controller
    {
        private IUserRepository UserRepository;
        private ICarRepository CarRepository;
        private IRefuellingRepository RefuellingRepository;

        public RefuellingController(IUserRepository userRepository, ICarRepository carRepository, IRefuellingRepository refuellingRepository)
        {
            UserRepository = userRepository;
            CarRepository = carRepository;
            RefuellingRepository = refuellingRepository;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            CarTrackr.Domain.User currentUser = UserRepository.RetrieveByUserName(this.HttpContext.User.Identity.Name);
            CarRepository.User = currentUser;
            
            base.OnActionExecuting(filterContext);
        }

        public ActionResult Index()
        {
            return RedirectToAction("List", "Car");
        }

        public ActionResult List(string licensePlate)
        {
            Car car = CarRepository.RetrieveByLicensePlate(licensePlate);
            List<Refuelling> refuellings = RefuellingRepository.List(car);

            var viewData = new RefuellingListViewData
            {
                Car = car,
                Refuellings = refuellings
            };

            return View("List", viewData);
        }

        [AcceptVerbs("GET")]
        public ActionResult New(string licensePlate)
        {
            Car car = CarRepository.RetrieveByLicensePlate(licensePlate);
            List<Refuelling> refuellings = RefuellingRepository.List(car);
            refuellings.Reverse();

            Refuelling refuelling = new Refuelling();
            refuelling.Date = DateTime.Now;

            var viewData = new NewRefuellingViewData
            {
                Car = car,
                LastRefuelling = refuellings.Count > 0 ? refuellings[0] : null,
                NewRefuelling = refuelling
            };

            return View("New", viewData);
        }

        [AcceptVerbs("POST")]
        public ActionResult New(string licensePlate, FormCollection form)
        {
            Car car = CarRepository.RetrieveByLicensePlate(licensePlate);
            Refuelling refuelling = null;

            try
            {
                refuelling = new Refuelling();
                refuelling.Car = car;

                this.UpdateModel(refuelling, new[] { "Date", "ServiceStation", "Kilometers", "Liters", "PricePerLiter", "Total", "Usage" });

                RefuellingRepository.Add(refuelling);

                return RedirectToAction("List", new { licensePlate = licensePlate });
            }
            catch (RuleViolationException)
            {
                List<Refuelling> refuellings = RefuellingRepository.List(car);
                refuellings.Reverse();

                this.UpdateModelStateWithViolations(refuelling, ViewData.ModelState);

                var viewData = new NewRefuellingViewData
                {
                    Car = car,
                    LastRefuelling = refuellings.Count > 0 ? refuellings[0] : null,
                    NewRefuelling = refuelling
                };
                
                return View("New", viewData);
            }
        }

        public ActionResult Remove(Guid id)
        {
            Refuelling refuelling = RefuellingRepository.RetrieveById(id);
            Car car = refuelling.Car;

            RefuellingRepository.Remove(refuelling);

            return RedirectToAction("List", new { licensePlate = car.LicensePlate });
        }
    }
}