using HRM.DAL;
using HRM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRM.BAL.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool AddEmployee(CreateEmployeeDTO model)
        {
            return _employeeRepository.AddEmployee(model);
        }

        public bool DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }

        public List<EmployeeDTO> getAllemployees()
        {
            return _employeeRepository.getAllemployees();
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }

        public bool UpdateEmployee(EmployeeDTO model)
        {
            return _employeeRepository.UpdateEmployee(model);
        }
    }
}
