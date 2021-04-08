
using AutoMapper;
using HRM.DAL.Database;
using HRM.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.DAL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Databasecontext _dataConext;
        public EmployeeRepository()
        {
            _dataConext = new Databasecontext();
        }
        public bool AddEmployee(EmployeeViewModel employee)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeViewModel, Employee>());
            var mapper = new Mapper(config);
            Employee emp = mapper.Map<Employee>(employee);

            _dataConext.Employees.Add(emp);
            return _dataConext.SaveChanges() > 0 ? true : false;

        }

        public bool DeleteEmployee(long id)
        {
            var ent = _dataConext.Employees.FirstOrDefault(x => x.Id == id);
            _dataConext.Employees.Remove(ent);
            return _dataConext.SaveChanges() > 0 ? true : false;
        }

        public List<EmployeeViewModel> GetAllEmployees()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeViewModel>());
            var mapper = new Mapper(config);
            List<EmployeeViewModel> empList = new List<EmployeeViewModel>();

            var entities = _dataConext.Employees.ToList();
            foreach (var item in entities)
            {
                EmployeeViewModel emp = mapper.Map<EmployeeViewModel>(item);
                empList.Add(emp);
            }
            return empList;
        }

        public EmployeeViewModel GetEmployeeById(long id)
        {
            var ent = _dataConext.Employees.FirstOrDefault(x=> x.Id == id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeViewModel>());
            var mapper = new Mapper(config);
            EmployeeViewModel emp = mapper.Map<EmployeeViewModel>(ent);
            return emp;
        }

        public bool UpdateEmployee(EmployeeViewModel employee)
        {
            var ent = _dataConext.Employees.FirstOrDefault(x => x.Id == employee.Id);
            
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeViewModel, Employee>());
            var mapper = new Mapper(config);
            Employee emp = mapper.Map<Employee>(employee);


            ent.Name = emp.Name;
            ent.Phone = emp.Phone;
            ent.Salary = emp.Salary;
            ent.Manager = emp.Manager;
            ent.IsManager = emp.IsManager;
            ent.Salary = emp.Salary;
            ent.Department = emp.Department;
            ent.Designation = emp.Designation;


            return _dataConext.SaveChanges() > 0 ? true : false;
        }
    }
}
