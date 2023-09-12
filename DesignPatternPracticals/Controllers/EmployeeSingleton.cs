using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternPracticals.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiVersion("1.0")]
    public class EmployeeSingleton : Controller
    {
        private readonly IDataAccessService _dataAccessService;

        public EmployeeSingleton(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public IActionResult Get(int? id)
        {
            var empList = _dataAccessService.GetAllEmployees(id);
            if(empList != null)
                return Ok(empList);
            return NotFound();
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public IActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                var addResult = _dataAccessService.CreateEmployee(employee);
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
        [MapToApiVersion("1.0")]
        public IActionResult Edit(int id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                var editResult = _dataAccessService.EditEmployee(id, employee);
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
        [MapToApiVersion("1.0")]
        public IActionResult Delete(int id)
        {
            var deleteResult = _dataAccessService.DeleteEmployee(id);
            if (deleteResult == true)
                return Ok("Employee deleted successfully");
            return BadRequest("Employee can't be deleted");
        }
    }
}
