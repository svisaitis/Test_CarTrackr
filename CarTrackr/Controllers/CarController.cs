using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using CarTrackr.Repository;
using CarTrackr.Data;
using CarTrackr.Domain;
using CarTrackr.Models;
using CarTrackr.Extensions;
using CarTrackr.Core;
using System.Data.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace CarTrackr.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private IUserRepository UserRepository;
        private ICarRepository CarRepository;
        private IRefuellingRepository RefuellingRepository;
        private ICostsRepository CostsRepository;

        public CarController(IUserRepository userRepository, ICarRepository carRepository, IRefuellingRepository refuellingRepository, ICostsRepository costsRepository)
        {
            UserRepository = userRepository;
            CarRepository = carRepository;
            RefuellingRepository = refuellingRepository;
            CostsRepository  = costsRepository;
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

        public ActionResult List()
        {
            List<Car> cars = CarRepository.List();

            var viewData = new CarListViewData
            {
                Cars = cars
            };

            return View("List", viewData);
        }

        public ActionResult Details(string licensePlate)
        {
            Car car = CarRepository.RetrieveByLicensePlate(licensePlate);

            var viewData = new CarDetailsViewData
            {
                Car = car,
                TotalKilometers = CostsRepository.CalculateTotalKilometers(car),
                AverageUsage = CostsRepository.CalculateAverageUsage(car),
                TotalCosts = CostsRepository.CalculateTotalCosts(car),
                AverageCosts = CostsRepository.CalculateAverageCostsPerKilometer(car)
            };

            return View("Details", viewData);
        }

        public ActionResult Statistics(string licensePlate)
        {
            if (!Request.IsAjaxRequest())
            {
                return RedirectToAction("Details", new { licensePlate = licensePlate });
            }

            Car car = CarRepository.RetrieveByLicensePlate(licensePlate);

            var viewData = new CarDetailsViewData
            {
                Car = car,
                TotalKilometers = CostsRepository.CalculateTotalKilometers(car),
                AverageUsage = CostsRepository.CalculateAverageUsage(car),
                TotalCosts = CostsRepository.CalculateTotalCosts(car),
                AverageCosts = CostsRepository.CalculateAverageCostsPerKilometer(car)
            };

            return View("StatisticsCarDetails", viewData);
        }

        [AcceptVerbs("GET")]
        public ActionResult Edit(string licensePlate)
        {
            Car car = CarRepository.RetrieveByLicensePlate(licensePlate);

            return View("Edit", car);
        }

        [AcceptVerbs("POST")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string licensePlate, FormCollection form)
        {
            Car car = CarRepository.RetrieveByLicensePlate(licensePlate);

            try
            {
                this.UpdateModel(car, new[] { "Make", "Model", "PurchasePrice", "FuelType", "Description" });
                car.LicensePlate = form["NewLicensePlate"];
                CarRepository.Update(car);

                return RedirectToAction("Details", new { licensePlate = car.LicensePlate });
            }
            catch (RuleViolationException)
            {
                this.UpdateModelStateWithViolations(car, ViewData.ModelState);

                car.LicensePlate = licensePlate;

                return View("Edit", car);
            }
        }

        [AcceptVerbs("GET")]
        public ActionResult New()
        {
            return View("New", new Car());
        }

        [AcceptVerbs("POST")]
        [ValidateAntiForgeryToken] 
        public ActionResult New(FormCollection form)
        {
            Car car = new Car();

            try
            {
                this.UpdateModel(car, new[] { "Make", "Model", "PurchasePrice", "LicensePlate", "FuelType", "Description" });
                CarRepository.Add(car);

                return RedirectToAction("Details", new { licensePlate = car.LicensePlate });
            }
            catch (RuleViolationException)
            {
                this.UpdateModelStateWithViolations(car, ViewData.ModelState);


                return View("New", car);
            }
        }
    }
}