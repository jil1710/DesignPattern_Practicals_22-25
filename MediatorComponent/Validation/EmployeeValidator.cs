using FluentValidation;
using MediatorComponent.Models;

namespace MediatorComponent.Validation
{
    public class EmployeeValidator: AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MaximumLength(50).WithMessage("Employee name length must be less than 50");
            RuleFor(e => e.Salary).NotEmpty();
            RuleFor(e => e.DepartmentId).NotEmpty().InclusiveBetween(1, 5).WithMessage("Invalid department id (must between 1 to 5)");
            RuleFor(e => e.EmailId).NotEmpty().EmailAddress().WithMessage("Please enter valid email address");
            RuleFor(e => e.JoiningDate).NotEmpty();     
        }
    }
}
