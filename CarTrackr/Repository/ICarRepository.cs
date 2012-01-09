using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarTrackr.Domain;

namespace CarTrackr.Repository
{
    public interface ICarRepository
    {
        User User { get; set; }
        List<Car> List();
        Car RetrieveById(Guid id);
        Car RetrieveByLicensePlate(string licensePlate);
        void Add(Car car);
        void Update(Car car);
    }
}
