using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using APICRUD.Models;
using APICRUD.EmployeeData;

namespace APICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }
        //returns all employees
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return  Ok(_employeeData.GetEmployees());
        }
        //returns one employee by searching for their ID in database
        [HttpGet("{Id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if(employee != null)
            {
                return Ok(_employeeData.GetEmployee(id));
            }
            return NotFound($"Employee with Id: {id} was not found");
           
        }
       
        [HttpPost("Create")]
        public IActionResult CreateEmployee(Employee employee)
        {
            
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path
                + "/" + employee.Id, employee);

        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            
                var employee= _employeeData.GetEmployee(id);    
                if(employee != null)
                {
                    _employeeData.DeleteEmployee(employee);
                 return Ok();
                }
            return NotFound($"Employee with Id: {id} was not found");
            
        }

        [HttpPut("Update")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            var existingemployee = _employeeData.GetEmployee(employee.Id);
            if(existingemployee != null)
            {
                _employeeData.UpdateEmployee(employee);
            }
            return Ok(employee);

        }
    }
}
