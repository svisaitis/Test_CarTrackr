using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarTrackr.Data;

namespace CarTrackr.Repository
{
    public interface IDataBoundRepository
    {
        CarTrackrData DataSource { get; set; }
    }
}
