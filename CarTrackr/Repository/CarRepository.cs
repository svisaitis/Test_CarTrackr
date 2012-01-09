using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarTrackr.Data;
using CarTrackr.Domain;
using CarTrackr.Controllers;

namespace CarTrackr.Repository
{
    public class CarRepository : IDataBoundRepository, ICarRepository
    {
        #region Constructor

        public CarRepository(CarTrackrData dataSource)
        {
            DataSource = dataSource;
        }

        #endregion

        #region IDataBoundRepository Members

        public CarTrackrData DataSource { get; set; }

        #endregion

        #region ICarRepository Members

        public User User { get; set; }

        public List<Car> List()
        {
            return DataSource.DataContext.Cars.Where(c => c.User == User).ToList();
        }

        Car ICarRepository.RetrieveById(Guid id)
        {
            return DataSource.DataContext.Cars.Where(c => c.Id == id).SingleOrDefault();
        }

        public Car RetrieveByLicensePlate(string licensePlate)
        {
            return DataSource.DataContext.Cars.Where(c => c.User == User && c.LicensePlate == licensePlate).SingleOrDefault();
        }

        public void Add(Car car)
        {
            if (car.User == null)
                car.User = User;

            car.EnsureValid();

            DataSource.DataContext.Cars.InsertOnSubmit(car);
            DataSource.DataContext.SubmitChanges();
        }

        public void Update(Car car)
        {
            car.EnsureValid();

            DataSource.DataContext.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, car);
            DataSource.DataContext.SubmitChanges();
        }

        #endregion
    }
}