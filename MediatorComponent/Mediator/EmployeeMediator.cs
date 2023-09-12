using MediatorComponent.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MediatorComponent.Mediator;

public class GetEmployeeQuery : IRequest<Employee>
{
    public int EmployeeId { get; set; }
}

public class CreateEmployeeCommand : IRequest<bool>
{
    public string Name { get; set; }
    public double Salary { get; set; }
    public int DepartmentId { get; set; }
    public string EmailId { get; set; }
    public DateTime? JoiningDate { get; set; }
    public bool Status { get; set; }
}

public class UpdateEmployeeCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
    public int DepartmentId { get; set; }
    public string EmailId { get; set; }
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? JoiningDate { get; set; }
    public bool Status { get; set; }
}

public class DeleteEmployeeCommand : IRequest<bool>
{
    public int Id { get; set; }
}
