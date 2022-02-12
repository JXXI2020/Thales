using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using ThalesTest.Models;
using Microsoft.AspNetCore.Http;

using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThalesTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<List<Employee>> Get()
        {
            
            
            HttpClient httpclient = new HttpClient();
            var json = await httpclient.GetStringAsync("http://dummy.restapiexample.com/api/v1/employees");

            DataEmployees cons = JsonConvert.DeserializeObject<DataEmployees>(json);
            List<Employee> employeeList = cons.data;
            return (employeeList);
            

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<List<Employee>> Get(string id)
        {
            HttpClient httpclient = new HttpClient();
            var json = await httpclient.GetStringAsync("http://dummy.restapiexample.com/api/v1/employee/" + id);

            DataEmployees cons = JsonConvert.DeserializeObject<DataEmployees>(json);
            List<Employee> employeeList = cons.data;

            return (employeeList);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
