using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRM.Models
{
    public class CreateEmployeeDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required")]
        [StringLength(maximumLength: 50, ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Department is Required")]
        public string Department { get; set; }

        [Required]
        public bool isManager { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Manager Name is Required")]
        public string Manager { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone is Required")]
        [StringLength(maximumLength: 10, ErrorMessage = "Maximum length is 10")]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
    public class EmployeeDTO : CreateEmployeeDTO
    {
        public int ID { get; set; }
    }
}
