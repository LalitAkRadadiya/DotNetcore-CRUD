using HRM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRM.DAL
{
    public interface IEmployeeRepository
    {
        List<EmployeeDTO> getAllemployees();
        bool AddEmployee(CreateEmployeeDTO model);
        bool DeleteEmployee(int id);
        bool UpdateEmployee(EmployeeDTO model);
        EmployeeDTO GetEmployeeById(int id);
    }
}
