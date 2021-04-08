using HRM.DAL.Database;
using HRM.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.DAL.Repository
{
    public interface IUserRepositpory
    {
        UserLoignViewModel login(UserLoignViewModel obj);
    }
}
