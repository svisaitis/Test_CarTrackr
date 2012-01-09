using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using CarTrackr.Domain;

namespace CarTrackr.Data
{
    public class CarTrackrData
    {
        private DataClassesDataContext dataContext;

        public DataClassesDataContext DataContext { 
            get {
                if (dataContext == null)
                {
                    dataContext = new DataClassesDataContext();

                    DataLoadOptions dataLoadOptions = new DataLoadOptions();
                    dataLoadOptions.LoadWith<Car>(c => c.User);
                    dataLoadOptions.LoadWith<Car>(c => c.Refuellings);
                    dataContext.LoadOptions = dataLoadOptions;
                }

                return dataContext;
            }
        }
    }
}
