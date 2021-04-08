using HRM.Model.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public EmployeeController()
        {
            client = new HttpClient();
            client.BaseAddress = baseUrl;
        }
        public IActionResult Index()
        {
            
            List<EmployeeViewModel> modelList = new List<EmployeeViewModel>();
            HttpResponseMessage res = client.GetAsync(client.BaseAddress+"/getallemployee").Result;
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);

            }
            return View(modelList);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        public ActionResult CreateOrEdit(EmployeeViewModel model)
        {
            if (model.Id == 0)
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync(client.BaseAddress + "/AddEmployee", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            else
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PutAsync(client.BaseAddress + "/EditEmployee", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View("Create", model);
            }
        }
        public ActionResult Edit(int id)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            HttpResponseMessage res = client.GetAsync(client.BaseAddress + "/GetEmployeeById/" + id).Result;
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<EmployeeViewModel>(data);

            }
            return View("Create",model);
        }
        


        public ActionResult Delete(int id)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            HttpResponseMessage res = client.DeleteAsync(client.BaseAddress + "/DeleteEmployee/" + id).Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
    }
}
