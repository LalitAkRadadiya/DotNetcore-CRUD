using HRM.BAL.Manager;
using HRM.Model.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _dbManager;
        private readonly Appsettings _appSettings;
        public UserController(IUserManager dbManager, IOptions<Appsettings> appSettings)
        {
            _dbManager = dbManager;
            _appSettings = appSettings.Value;

        }

        [HttpPost]
        [Route("login")]
        public IActionResult login(UserLoignViewModel model)
        {
            var result = _dbManager.login(model);
            if (result != null)
            {
                
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name,model.email.ToString()),
                    new Claim(ClaimTypes.Role,"Admin"),
                    new Claim(ClaimTypes.Version,"V3.1")
                    }),
                    Expires = DateTime.UtcNow.AddDays(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                model.password = null;
                model.token = tokenHandler.WriteToken(token);

                return Ok(model);
            }
            return BadRequest(new { message = "soemting Went worong" });
        }

    }
}
