using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using ThalesTest.Models;

namespace ThalesTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {

            // http://dummy.restapiexample.com/api/v1/employees
            HttpClient httpclient = new HttpClient();
            var json = await httpclient.GetStringAsync("http://dummy.restapiexample.com/api/v1/employees");

            DataEmployees cons = JsonConvert.DeserializeObject<DataEmployees>(json);
            List<Employee> employeeList = cons.data;




            return View(employeeList);
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