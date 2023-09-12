using MediatorComponent.Models;
using MediatorComponent.Repository;
using MediatR;

namespace MediatorComponent.Mediator;

public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Employee>
{
    private readonly IEmployeeRepositoryforMediator _repository;

    public GetEmployeeQueryHandler(IEmployeeRepositoryforMediator repository)
    {
        _repository = repository;
    }

    public async Task<Employee> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetById(request.EmployeeId);
    }
}


public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, bool>
{
    private readonly IEmployeeRepositoryforMediator _repository;

    public CreateEmployeeCommandHandler(IEmployeeRepositoryforMediator repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee() { Name = request.Name, DepartmentId = request.DepartmentId, EmailId = request.EmailId, JoiningDate = request.JoiningDate, Salary = request.Salary, Status = request.Status};
        return await _repository.AddAsync(employee);
    }
}

public class UpdateEmployeeCommandHandler: IRequestHandler<UpdateEmployeeCommand, bool>
{
    private readonly IEmployeeRepositoryforMediator _repository;

    public UpdateEmployeeCommandHandler(IEmployeeRepositoryforMediator repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee() { Id = request.Id, Name = request.Name, DepartmentId = request.DepartmentId, EmailId = request.EmailId, JoiningDate = request.JoiningDate, Salary = request.Salary, Status = request.Status };
        return await _repository.UpdateAsync(employee);
    }
}

public class DeleteEmployeeCommandHandler: IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IEmployeeRepositoryforMediator _repository;

    public DeleteEmployeeCommandHandler(IEmployeeRepositoryforMediator repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id);
    }
}
