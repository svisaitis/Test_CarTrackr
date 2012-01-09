using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarTrackr.Repository;
using CarTrackr.Domain;

namespace CarTrackr.Tests.Repository
{
    public class CarRepository : ICarRepository
    {
        public DataStore DataStore { get; set; }
        public CarRepository(DataStore dataStore)
        {
            DataStore = dataStore;
        }

        #region ICarRepository Members

        public User User { get; set; }

        public List<Car> List()
        {
            return DataStore.Cars.Where(c => c.User == User).ToList();
        }

        Car ICarRepository.RetrieveById(Guid id)
        {
            return DataStore.Cars.Where(c => c.Id == id).SingleOrDefault();
        }

        public Car RetrieveByLicensePlate(string licensePlate)
        {
            return DataStore.Cars.Where(c => c.User == User && c.LicensePlate == licensePlate).SingleOrDefault();
        }

        public void Add(Car car)
        {
            if (car.User == null)
                car.User = User;

            car.EnsureValid();

            DataStore.Cars.Add(car);
        }

        public void Update(Car car)
        {
            car.EnsureValid();
        }

        #endregion
    }
}
