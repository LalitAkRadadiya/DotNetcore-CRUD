using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using HRM.DAL;
using HRM.DAL.Repository;

namespace HRM.BAL.Helper
{
    public static class DIHelper
    {
        public static IServiceCollection RegisterBuisnessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDatabase(configuration);
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}
