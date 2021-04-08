using HRM.BAL;
using HRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace HRM.WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [Route("GetEmployees")]
        [HttpGet]
        public IActionResult GetEmployee()
        {
            var employees = _employeeManager.getAllemployees();
            if(employees.Count() != 0)
            {
                return Ok(JsonSerializer.Serialize(employees));
            }
            else
            {
                return StatusCode(500);
            }
        }

        [Route("GetEmployeeById/{id}")]
        [HttpGet]
        public IActionResult GetEmployeeById(int id)
        {
            var result = _employeeManager.GetEmployeeById(id);
            if (result != null)
            {
                return Ok(JsonSerializer.Serialize(result));
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee(CreateEmployeeDTO model)
        {
            var result = _employeeManager.AddEmployee(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("EditEmployee")]
        public IActionResult UpdateEmployee(EmployeeDTO model)
        {
            var result = _employeeManager.UpdateEmployee(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var result = _employeeManager.DeleteEmployee(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
