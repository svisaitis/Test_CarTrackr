using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarTrackr.Repository;

namespace CarTrackr.Tests.Repository
{
    public class UserRepository : IUserRepository
    {
        public DataStore DataStore { get; set; }
        public UserRepository(DataStore dataStore)
        {
            DataStore = dataStore;
        }

        #region IUserRepository Members

        public CarTrackr.Domain.User RetrieveByUserName(string userName)
        {
            return DataStore.Users.Where(u => u.UserName == userName).SingleOrDefault();
        }

        #endregion
    }
}
