using FluentValidation;
using MediatorComponent.Mediator;
using MediatorComponent.Models;
using MediatorComponent.Validation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternPracticals.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiVersion("4.0")]
    public class MediatorPatternDemoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<Employee> _employeeValidator;

        public MediatorPatternDemoController(IMediator mediator, IValidator<Employee> empoyeeValidator)
        {
            _mediator = mediator;
            _employeeValidator = empoyeeValidator;
        }

        [HttpGet("{id}")]
        [MapToApiVersion("4.0")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var query = new GetEmployeeQuery { EmployeeId = id };
                var employee = await _mediator.Send(query);
                return Ok(employee);
            }
            catch
            {
                return BadRequest(new { error = "Please enter valid user id" });
            }
        }


        [HttpPost]
        [MapToApiVersion("4.0")]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            var modelState = await _employeeValidator.ValidateAsync(employee);
            if (modelState.IsValid)
            {
                var query = new CreateEmployeeCommand
                {
                    Name = employee.Name,
                    Salary = employee.Salary,
                    DepartmentId = employee.DepartmentId,
                    EmailId = employee.EmailId,
                    JoiningDate = employee.JoiningDate,
                    Status = employee.Status,
                };
                var response = await _mediator.Send(query);
                if (response)
                    return Ok("Employee added successfully");
                return BadRequest("Employee can't be added");
            }
            else
            {
                return BadRequest();
            }
            
        }


        [HttpPut]
        [MapToApiVersion("4.0")]
        public async Task<IActionResult> EditEmployee(int id, Employee employee)
        {
            if (_employeeValidator.Validate(employee).IsValid)
            {
                var query = new UpdateEmployeeCommand
                {
                    Id = id,
                    Name = employee.Name,
                    Salary = employee.Salary,
                    DepartmentId = employee.DepartmentId,
                    EmailId = employee.EmailId,
                    JoiningDate = employee.JoiningDate,
                    Status = employee.Status,
                };
                var response = await _mediator.Send(query);
                if (response)
                    return Ok("Employee details edited successfully");
                return BadRequest("Employee details can't be updated");
            }
            else
            {
                return BadRequest("Please enter valid employee details");
            }
            
        }


        [HttpDelete]
        [MapToApiVersion("4.0")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var response = await _mediator.Send(new DeleteEmployeeCommand() { Id = id});
            if(response)
                return Ok("Employee deleted successfully");
            return BadRequest("Employee can't be deleted");
        }
    }
}
