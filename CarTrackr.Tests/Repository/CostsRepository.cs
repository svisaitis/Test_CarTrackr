using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarTrackr.Data;
using CarTrackr.Domain;
using CarTrackr.Controllers;
using CarTrackr.Repository;

namespace CarTrackr.Tests.Repository
{
    public class CostsRepository : ICostsRepository
    {
        public DataStore DataStore { get; set; }
        public CostsRepository(DataStore dataStore, ICarRepository carRepository, IRefuellingRepository refuellingRepository)
        {
            DataStore = dataStore;
            CarRepository = carRepository;
            RefuellingRepository = refuellingRepository;
        }

        #region ICostsRepository Members

        public ICarRepository CarRepository { get; set; }
        public IRefuellingRepository RefuellingRepository { get; set; }

        public decimal CalculateTotalKilometers(Car car)
        {
            List<Refuelling> refuellings = RefuellingRepository.List(car);
            refuellings.Reverse();

            decimal returnValue = 0;
            int index = 0;
            while (returnValue == 0 && refuellings.Count > 0)
            {
                returnValue = refuellings[index].Kilometers;
                index++;
            }

            return returnValue;
        }

        public decimal CalculateAverageUsage(Car car)
        {
            List<Refuelling> refuellings = RefuellingRepository.List(car);

            decimal returnValue = 0;
            int count = 0;
            foreach (var refuelling in refuellings)
            {
                if (refuelling.Usage > 0)
                {
                    returnValue += refuelling.Usage;
                    count++;
                }
            }
            if (count > 0)
            {
                returnValue = returnValue / count;
            }

            return returnValue;
        }

        public decimal CalculateTotalCosts(Car car)
        {
            List<Refuelling> refuellings = RefuellingRepository.List(car);
            refuellings.Reverse();

            decimal returnValue = 0;
            returnValue += car.PurchasePrice;

            foreach (var refuelling in refuellings)
            {
                returnValue += refuelling.Total;
            }

            return returnValue;
        }

        public decimal CalculateAverageCostsPerKilometer(Car car)
        {
            try
            {
                return CalculateTotalCosts(car) / CalculateTotalKilometers(car);
            }
            catch {
                return 0;
            }
        }

        #endregion
    }
}