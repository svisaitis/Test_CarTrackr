using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarTrackr.Repository;
using CarTrackr.Domain;

namespace CarTrackr.Tests.Repository
{
    public class RefuellingRepository : IRefuellingRepository
    {
        public DataStore DataStore { get; set; }
        public RefuellingRepository(DataStore dataStore)
        {
            DataStore = dataStore;
        }

        #region IRefuellingRepository Members

        public List<Refuelling> List(Car car)
        {
            return DataStore.Refuellings.Where(r => r.Car == car).OrderBy(r => r.Date).ToList();
        }

        public Refuelling RetrieveById(Guid id)
        {
            return DataStore.Refuellings.Where(r => r.Id == id).SingleOrDefault();
        }

        public void Add(Refuelling refuelling)
        {
            refuelling.EnsureValid();

            DataStore.Refuellings.Add(refuelling);
        }

        public void Update(Refuelling refuelling)
        {
            refuelling.EnsureValid();
        }

        public void Remove(Refuelling refuelling)
        {
            DataStore.Refuellings.Remove(refuelling);
        }

        #endregion
    }
}
