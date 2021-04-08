using HRM.Model.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRM.MVC.Controllers
{
    public class UserController : Controller
    {
        Uri baseUrl = new Uri("https://localhost:44354/api/user");
        HttpClient client;

        public UserController()
        {
            client = new HttpClient();
            client.BaseAddress = baseUrl;
        }

        public IActionResult Login()
        {
            ViewBag.message = TempData["message"];
            return View();
        }
        async public Task<IActionResult> LoginUser(UserLoignViewModel model)
        {
            if (model.Id == 0)
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync(client.BaseAddress + "/login", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.email),
                        new Claim(ClaimTypes.Role, "Administrator"),
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                        IsPersistent = true
                    };
                    await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);
                    
                    TempData["message"] = "Login Successfully";
                    return RedirectToAction("Index","Employee");
                }

                TempData["message"] = "InCorrect Credential";
                return RedirectToAction("Login","User");
            }
            else
            {


                TempData["message"] = "Plz Enter Email and Password";
                return View("Login");
            }
        }

        async public Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
