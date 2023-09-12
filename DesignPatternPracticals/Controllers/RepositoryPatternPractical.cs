using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Models;

namespace DesignPatternPracticals.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiVersion("3.0")]
    public class RepositoryPatternPractical : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public RepositoryPatternPractical(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [MapToApiVersion("3.0")]
        public IActionResult Get(int? id)
        {
            var empList = _employeeRepository.GetAllEmployees(id);
            if (empList != null)
                return Ok(empList);
            return NotFound();
        }

        [HttpPost]
        [MapToApiVersion("3.0")]
        public IActionResult Create(EmployeeR employee)
        {
            if(ModelState.IsValid)
            {
                var addResult = _employeeRepository.CreateEmployee(employee);
                if (addResult == true)
                    return Ok("Employee added successfully");
                return BadRequest("There is some error while inserting employee");
            }
            else
            {
                return BadRequest("Please enter valid employee details");
            }
            
        }

        [HttpPut]
        [MapToApiVersion("3.0")]
        public IActionResult Edit(int id, EmployeeR employee)
        {
            if(ModelState.IsValid)
            {
                var editResult = _employeeRepository.EditEmployee(id, employee);
                if (editResult == true)
                    return Ok("Employee edited successfully");
                return BadRequest("Employee can't be edited");
            }
            else
            {
                return BadRequest("Please enter valid employee details");
            }
            
        }

        [HttpDelete]
        [MapToApiVersion("3.0")]
        public IActionResult Delete(int id)
        {
            var deleteResult = _employeeRepository.DeleteEmployee(id);
            if (deleteResult == true)
                return Ok("Employee deleted successfully");
            return BadRequest("Employee can't be deleted");
        }
    }
}
