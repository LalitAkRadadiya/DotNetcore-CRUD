using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRM.Model.Model
{
    public class UserLoignViewModel
    {
        public int Id { get; set; }
        public string username { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Email Required For Login")]
        [DataType(DataType.EmailAddress)]
        
        public string email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required For Login")]
        [DataType(DataType.Password)]
        [MinLength(5,ErrorMessage ="min 5 char Requried")]
        public string password { get; set; }
    }
}
