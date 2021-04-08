using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRM.DAL.Database
{
    public class UserReg
    {
        [Key]
        public int Id { get; set; }

        public string username { get; set; }

        public string email { get; set; }
        public string password{ get; set; }
    }
}
