using HRM.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.BAL.Manager
{
    public interface IUserManager
    {
        UserLoignViewModel login(UserLoignViewModel obj);
    }
}
