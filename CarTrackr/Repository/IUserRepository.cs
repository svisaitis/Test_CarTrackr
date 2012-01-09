using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarTrackr.Domain;

namespace CarTrackr.Repository
{
    public interface IUserRepository
    {
        User RetrieveByUserName(string userName);
    }
}
