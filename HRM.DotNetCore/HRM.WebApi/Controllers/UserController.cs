using HRM.BAL.Manager;
using HRM.Model.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _dbManager;
        public UserController(IUserManager dbManager)
        {
            _dbManager = dbManager;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult login(UserLoignViewModel model)
        {
            var result = _dbManager.login(model);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

    }
}
