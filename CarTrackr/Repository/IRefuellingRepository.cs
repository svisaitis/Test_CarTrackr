using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarTrackr.Domain;

namespace CarTrackr.Repository
{
    public interface IRefuellingRepository
    {
        List<Refuelling> List(Car car);
        Refuelling RetrieveById(Guid id);
        void Add(Refuelling refuelling);
        void Update(Refuelling refuelling);
        void Remove(Refuelling refuelling);
    }
}
