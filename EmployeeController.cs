using EmployeesAPI.Models;
using EmployeesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Employee>> GetAll() => EmployeeServices.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id) 
        {
            var employee = EmployeeServices.GetEmployee(id);
            if(employee == null) 
                return NotFound();
            return employee;
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            EmployeeServices.Add(employee);
            return CreatedAtAction(nameof(Create), new { id = employee.EmployeeID }, employee);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id,Employee employee) 
        {
            if(id != employee.EmployeeID) return BadRequest();
            var existingEmployees = EmployeeServices.GetEmployee(id);
            if (existingEmployees is null) return NotFound();
            EmployeeServices.Update(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            var employee = EmployeeServices.GetEmployee(id);
            if (employee is null)
                return NotFound();
            EmployeeServices.Delete(id);
            return NoContent();
        }


    }
}
