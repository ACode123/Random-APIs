using consumeapiiiii.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using consumeapiiiii.Helper;
using APICRUD.Data.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace consumeapiiiii.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        APIHelper _api = new APIHelper();
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public HomeController(EmployeeData dataStore)
        {
        }

        //gets all data in the api 
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<EmployeeData> employees = new List<EmployeeData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/Employees");
            if(response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                employees=JsonConvert.DeserializeObject<List<EmployeeData>>(results);
            }
            return View(employees);
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            var employee = new EmployeeData();
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync($"api/Employees/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<EmployeeData>(results);
            }
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeData employee)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PostAsJsonAsync <EmployeeData>("api/Employees/Create", employee);
            postTask.Wait();
            var result = postTask.Result;
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            
            return View();
        }
        public async Task<IActionResult> Delete(Guid Id)
        {
            var employeee = new EmployeeData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/Employees/{Id}");

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
