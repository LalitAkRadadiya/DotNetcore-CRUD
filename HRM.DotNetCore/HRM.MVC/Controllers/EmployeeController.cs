using HRM.Model.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HRM.MVC.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        Uri baseUrl = new Uri("https://localhost:44354/api/Employee");
        HttpClient client;
        private readonly ILogger _logger;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
            client = new HttpClient();
            client.BaseAddress = baseUrl;
        }

        [ResponseCache(Duration = 5000)]
        public IActionResult Index()
        {
            try
            {
                ViewBag.data = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
                List<EmployeeViewModel> modelList = new List<EmployeeViewModel>();
                HttpResponseMessage res = client.GetAsync(client.BaseAddress + "/getallemployee").Result;
                if (res.IsSuccessStatusCode)
                {
                    string data = res.Content.ReadAsStringAsync().Result;
                    modelList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);

                }


                return View(modelList);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(new List<EmployeeViewModel>());
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        
        public ActionResult CreateOrEdit(EmployeeViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            try
            {
                if (model.Id == 0)
                {
                    HttpResponseMessage res = client.PostAsync(client.BaseAddress + "/AddEmployee", content).Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    return View();
                }
                else
                {
                    HttpResponseMessage res = client.PutAsync(client.BaseAddress + "/EditEmployee", content).Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    return View("Create", model);
                }
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            try
            {

                EmployeeViewModel model = new EmployeeViewModel();
                HttpResponseMessage res = client.GetAsync(client.BaseAddress + "/GetEmployeeById/" + id).Result;
                if (res.IsSuccessStatusCode)
                {
                    string data = res.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<EmployeeViewModel>(data);

                }
                return View("Create", model);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View("Index");

            }
        }
        


        public ActionResult Delete(int id)
        {
            try
            {
                EmployeeViewModel model = new EmployeeViewModel();
                HttpResponseMessage res = client.DeleteAsync(client.BaseAddress + "/DeleteEmployee/" + id).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);

                return RedirectToAction("Index");
            }
        }
    }
}
