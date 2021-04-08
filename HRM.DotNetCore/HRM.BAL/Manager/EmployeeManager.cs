using HRM.DAL.Repository;
using HRM.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.BAL.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository  _dbRepositpory;

        public EmployeeManager(IEmployeeRepository dbRepository)
        {
            _dbRepositpory = dbRepository;
        }
        public bool AddEmployee(EmployeeViewModel employee)
        {
            return _dbRepositpory.AddEmployee(employee);
        }

        public bool DeleteEmployee(long id)
        {
            return _dbRepositpory.DeleteEmployee(id);
        }

        public List<EmployeeViewModel> GetAllEmployees()
        {
            return _dbRepositpory.GetAllEmployees();
        }

        public EmployeeViewModel GetEmployeeById(long id)
        {
            return _dbRepositpory.GetEmployeeById(id);
        }

        public bool UpdateEmployee(EmployeeViewModel employee)
        {
            return _dbRepositpory.UpdateEmployee(employee);
        }
    }
}
