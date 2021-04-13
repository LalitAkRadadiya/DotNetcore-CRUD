using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRM.Model.Model
{
    public class EmployeeViewModel
    {
        public long Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name Required For Login")]
        [MinLength(3, ErrorMessage = "Min 3 char Requried")]

        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Department Required For Login")]
        [MinLength(2, ErrorMessage = "Min 2 char Requried")]
        public string Department { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Designation Required For Login")]
        [MinLength(2, ErrorMessage = "Min 2 char Requried")]
        public string Designation { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Salary Required For Login")]
        public decimal Salary { get; set; }

        public bool IsManager { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Manager Required For Login")]
        [MinLength(3, ErrorMessage = "Min 3 char Requried")]

        public string Manager { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Designation Required For Login")]
        [MinLength(10, ErrorMessage = "Min 10 char Requried")]

        public string Phone { get; set; }
        

        [DataType(DataType.EmailAddress)]


        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Required")]
    public string Email { get; set; }


    }
}
