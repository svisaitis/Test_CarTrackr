using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarTrackr.Data;
using CarTrackr.Domain;

namespace CarTrackr.Repository
{
    public class UserRepository : IDataBoundRepository, IUserRepository
    {
        #region Constructor

        public UserRepository(CarTrackrData dataSource)
        {
            DataSource = dataSource;
        }

        #endregion

        #region IDataBoundRepository Members

        public CarTrackrData DataSource { get; set; }

        #endregion

        #region IUserRepository Members

        public User RetrieveByUserName(string userName)
        {
            return DataSource.DataContext.Users.Where(u => u.UserName == userName).SingleOrDefault();
        }

        #endregion
    }
}
