using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarTrackr.Domain;

namespace CarTrackr.Tests.Repository
{
    public class DataStore
    {
        public List<User> Users { get; set; }
        public List<Car> Cars { get; set; }
        public List<Refuelling> Refuellings { get; set; }

        public DataStore()
        {
            // Users
            Users = new List<User>();
            Users.Add(new User() { UserId = Guid.NewGuid(), UserName = "testuser1" });
            Users.Add(new User() { UserId = Guid.NewGuid(), UserName = "testuser2" });

            // Cars
            Cars = new List<Car>();
            Cars.Add(new Car() { Id = Guid.NewGuid(), User = Users[0], OwnerId = Users[0].UserId, Make = "testmake1", Model = "testmodel1", LicensePlate = "testplate1", FuelType = "testfuel1", Description = "testdescription1" });
            Cars.Add(new Car() { Id = Guid.NewGuid(), User = Users[1], OwnerId = Users[1].UserId, Make = "testmake2", Model = "testmodel2", LicensePlate = "testplate2", FuelType = "testfuel2", Description = "testdescription2" });

            // Refuellings
            Refuellings = new List<Refuelling>();
            Refuellings.Add(new Refuelling() { Id = Guid.NewGuid(), Car = Cars[0], CarId = Cars[0].Id, Date = DateTime.Now, Kilometers = 100, Liters = 100, PricePerLiter = 2, ServiceStation = "testservicestation1", Total = 200, Usage = 100 });
            Refuellings.Add(new Refuelling() { Id = Guid.NewGuid(), Car = Cars[0], CarId = Cars[0].Id, Date = DateTime.Now, Kilometers = 100, Liters = 200, PricePerLiter = 2, ServiceStation = "testservicestation1", Total = 200, Usage = 100 });
            Refuellings.Add(new Refuelling() { Id = Guid.NewGuid(), Car = Cars[1], CarId = Cars[1].Id, Date = DateTime.Now, Kilometers = 100, Liters = 100, PricePerLiter = 2, ServiceStation = "testservicestation2", Total = 200, Usage = 100 });
            Refuellings.Add(new Refuelling() { Id = Guid.NewGuid(), Car = Cars[1], CarId = Cars[1].Id, Date = DateTime.Now, Kilometers = 100, Liters = 200, PricePerLiter = 2, ServiceStation = "testservicestation2", Total = 200, Usage = 100 });
        }
    }
}
