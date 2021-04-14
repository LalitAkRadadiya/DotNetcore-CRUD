using HRM.BAL.Manager;
using HRM.Model.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace HRM.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
   
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _dbManager;
        public EmployeeController(IEmployeeManager dbManager)
        {
            _dbManager = dbManager;
        }

        [Route("GetAllEmployee")]
        public IActionResult GetAllEmployee() 
        {
            return Ok(_dbManager.GetAllEmployees());
        }
        [Route("GetEmployeeById/{id}")]
        [HttpGet]
        public IActionResult GetEmployeeById(int id)
        {
             var result = _dbManager.GetEmployeeById(id);
             return Ok(result);
          
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee(EmployeeViewModel model)
        {
            var result = _dbManager.AddEmployee(model);
            return Ok(result);
        }

        [HttpPut]
        [Route("EditEmployee")]
        public IActionResult UpdateEmployee(EmployeeViewModel model)
        {
            var result = _dbManager.UpdateEmployee(model);
            return Ok(result);
           
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var result = _dbManager.DeleteEmployee(id);
           
                return Ok();
        
        }


    }
}
