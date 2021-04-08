using HRM.DAL.Database;
using HRM.DAL.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.BAL.DIHelper
{
    public static class DIHelper
    {
        public static void DependencyHelper(ref IServiceCollection ser)
        {
            ser.AddDbContext<Databasecontext>();
            ser.AddScoped<IEmployeeRepository, EmployeeRepository>();
            ser.AddScoped<IUserRepositpory, UserRepositpory>();
        }

    }
}
