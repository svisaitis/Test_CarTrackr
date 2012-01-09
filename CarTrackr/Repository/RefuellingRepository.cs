using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarTrackr.Data;
using CarTrackr.Domain;

namespace CarTrackr.Repository
{
    public class RefuellingRepository : IDataBoundRepository, IRefuellingRepository
    {
        #region Constructor

        public RefuellingRepository(CarTrackrData dataSource)
        {
            DataSource = dataSource;
        }

        #endregion

        #region IDataBoundRepository Members

        public CarTrackrData DataSource { get; set; }

        #endregion

        #region IRefuellingRepository Members

        public List<Refuelling> List(Car car)
        {
            return DataSource.DataContext.Refuellings.Where(r => r.Car == car).OrderBy(r => r.Date).ToList();
        }

        public Refuelling RetrieveById(Guid id)
        {
            return DataSource.DataContext.Refuellings.Where(r => r.Id == id).SingleOrDefault();
        }

        public void Add(Refuelling refuelling)
        {
            refuelling.EnsureValid();

            DataSource.DataContext.Refuellings.InsertOnSubmit(refuelling);
            DataSource.DataContext.SubmitChanges();
        }

        public void Update(Refuelling refuelling)
        {
            refuelling.EnsureValid();

            DataSource.DataContext.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, refuelling);
            DataSource.DataContext.SubmitChanges();
        }

        public void Remove(Refuelling refuelling)
        {
            DataSource.DataContext.Refuellings.DeleteOnSubmit(refuelling);
            DataSource.DataContext.SubmitChanges();
        }

        #endregion
    }
}
