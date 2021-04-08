using HRM.DAL.Repository;
using HRM.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.BAL.Manager
{

    public class UserManager : IUserManager
    {
        private readonly IUserRepositpory _dbRepositpory;

        public UserManager(IUserRepositpory dbRepository)
        {
            _dbRepositpory = dbRepository;
        }
        public UserLoignViewModel login(UserLoignViewModel obj)
        {
            return _dbRepositpory.login(obj);
        }
    }
}
