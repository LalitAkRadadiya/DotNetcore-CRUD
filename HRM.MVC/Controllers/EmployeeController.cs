using HRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HRM.MVC.Controllers
{
    //[AuthSessionManagement]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmployee(EmployeeDTO employee)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    string postUri = "https://localhost:44367/AddEmployee";

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<EmployeeDTO>(postUri, employee);
                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("EmployeeList", "Employee");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(employee);
        }

        [HttpGet]
        [ResponseCache(Duration = (int)0.5)]
        public IActionResult EmployeeList()
        {
            IEnumerable<EmployeeDTO> employees = null;
            using (var client = new HttpClient())
            {
                string getUri = "https://localhost:44367/GetEmployees";

                //HTTP GET
                var responseTask = client.GetAsync(getUri);

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IEnumerable<EmployeeDTO>>();
                    employees = readTask.Result;
                }
                else
                {
                    employees = Enumerable.Empty<EmployeeDTO>();
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                }
            }
            return View(employees);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            else
            {
                var employee = GetEmployeeById(id);
                return View(employee);
            }
        }

        [HttpGet]
        public IActionResult DeleteEmployee(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var employee = GetEmployeeById(id);

            if(employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmployee(int id)
        {
            using (var client = new HttpClient())
            {
                var deleteUri = "https://localhost:44367/DeleteEmployee/" + id;

                //HTTP DELETE
                var deleteTask = client.DeleteAsync(deleteUri);
                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("EmployeeList", "Employee");
                }
            }
            return RedirectToAction("EmployeeList", "Employee");
        }

        [HttpGet]
        public IActionResult EditEmployee(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var employee = GetEmployeeById(id);

            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [NonAction]
        public EmployeeDTO GetEmployeeById(int? id)
        {
            EmployeeDTO employee = null;

            using (var client = new HttpClient())
            {
                string getUri = "https://localhost:44367/GetEmployeeById/" + id;

                //HTTP GET
                var responseTask = client.GetAsync(getUri);

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<EmployeeDTO>();
                    employee = readTask.Result;
                }
                else
                {
                    employee = null;
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                }
            }
            return employee;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEmployee(EmployeeDTO employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        string putUri = "https://localhost:44367/EditEmployee";

                        //HTTP GET
                        var responseTask = client.PutAsJsonAsync<EmployeeDTO>(putUri, employee);

                        var result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            return RedirectToAction("EmployeeList", "Employee");
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {

                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(employee);
        }
    }
}
