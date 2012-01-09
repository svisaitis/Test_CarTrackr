using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarTrackr.Data;
using CarTrackr.Domain;
using CarTrackr.Controllers;

namespace CarTrackr.Repository
{
    public class CostsRepository : IDataBoundRepository, ICostsRepository
    {
        #region Constructor

        public CostsRepository(CarTrackrData dataSource, ICarRepository carRepository, IRefuellingRepository refuellingRepository)
        {
            DataSource = dataSource;
            CarRepository = carRepository;
            RefuellingRepository = refuellingRepository;
        }

        #endregion

        #region IDataBoundRepository Members

        public CarTrackrData DataSource { get; set; }

        #endregion

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
            catch
            {
                return 0;
            }
        }

        #endregion
    }
}