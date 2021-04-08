
using HRM.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.DAL.Repository
{
    public interface IEmployeeRepository
    {
        List<EmployeeViewModel> GetAllEmployees();
        EmployeeViewModel GetEmployeeById(long id);
        bool AddEmployee(EmployeeViewModel employee);
        bool UpdateEmployee(EmployeeViewModel employee);
        bool DeleteEmployee(long id);
    }
}
