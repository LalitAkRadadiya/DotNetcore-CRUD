using HRM.Model.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;
        public UserController(ILogger<UserController> logger)
        {

            _logger = logger;
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
                    var name = res.Content.ReadAsStringAsync();
                    UserLoignViewModel user = JsonConvert.DeserializeObject<UserLoignViewModel>(name.Result);

                    if (user != null)
                    {

                        HttpContext.Session.SetString("token", user.token);

                        return RedirectToAction("Index", "Employee");

                    }
                    else
                    {
                        return RedirectToAction("login", "User");

                    }

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
