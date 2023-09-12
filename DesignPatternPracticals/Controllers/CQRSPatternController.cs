using CQRSPattern.Interfaces;
using CQRSPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternPracticals.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiVersion("5.0")]
    public class CQRSPatternController : Controller
    {
        private readonly IEmployeeQueryRepository _employeeQueryRepository;
        private readonly IEmployeeCommandRepository _employeeCommandRepository;

        public CQRSPatternController(IEmployeeQueryRepository employeeQueryRepository,
                                    IEmployeeCommandRepository employeeCommandRepository)
        {
            _employeeQueryRepository = employeeQueryRepository;
            _employeeCommandRepository = employeeCommandRepository;
        }

        [HttpGet]
        [MapToApiVersion("5.0")]
        public IActionResult GetAll()
        {
            var employees = _employeeQueryRepository.GetAll();
            if (employees != null)
                return Ok(employees);
            return BadRequest();
        }

        [HttpGet]
        [MapToApiVersion("5.0")]
        public IActionResult GetById(int id)
        {
            var emp = _employeeQueryRepository.GetById(id);
            if (emp.Id != 0)
                return Ok(emp);
            return NotFound();
        }

        [HttpPost]
        [MapToApiVersion("5.0")]
        public IActionResult CreateEmployee(EmployeeCommandModel employeeCommandModel)
        {
            if (ModelState.IsValid)
            {
                var createdEmp = _employeeCommandRepository.CreateEmployee(employeeCommandModel);
                if (createdEmp == true)
                    return Ok("Employee created successfully");
                return BadRequest("Employee can't be created");
            }
            else
            {
                return BadRequest("Please enter valid employee details");
            }

        }

        [HttpPut]
        [MapToApiVersion("5.0")]
        public IActionResult EditEmployee(int id, EmployeeCommandModel employeeCommandModel)
        {
            if (ModelState.IsValid)
            {
                var editedEmp = _employeeCommandRepository.EditEmployee(id, employeeCommandModel);
                if (editedEmp == true)
                    return Ok("Employee edited successfully");
                return BadRequest("Employee can't be edited");
            }
            else
            {
                return BadRequest("Please enter valid employee details");
            }
        }

        [HttpDelete]
        [MapToApiVersion("5.0")]
        public IActionResult DeleteEmployee(int id)
        {
            var deletedEmp = _employeeCommandRepository.DeleteEmployee(id);
            if (deletedEmp == true)
                return Ok("Employee deleted successfully");
            return BadRequest("Employee can't be deleted");
        }
    }
}
