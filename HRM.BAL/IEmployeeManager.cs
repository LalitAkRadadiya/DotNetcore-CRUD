using HRM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRM.BAL
{
    public interface IEmployeeManager
    {
        List<EmployeeDTO> getAllemployees();
        bool AddEmployee(CreateEmployeeDTO model);
        bool DeleteEmployee(int id);
        bool UpdateEmployee(EmployeeDTO model);
        EmployeeDTO GetEmployeeById(int id);
    }
}
