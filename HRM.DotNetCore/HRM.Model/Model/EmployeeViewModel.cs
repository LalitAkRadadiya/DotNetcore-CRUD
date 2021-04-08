using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.Model.Model
{
    public class EmployeeViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }
        public bool IsManager { get; set; }
        public string Manager { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
