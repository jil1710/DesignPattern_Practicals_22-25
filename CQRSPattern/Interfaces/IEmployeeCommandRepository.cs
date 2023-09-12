using CQRSPattern.Models;

namespace CQRSPattern.Interfaces
{
    public interface IEmployeeCommandRepository
    {
        bool CreateEmployee(EmployeeCommandModel employeeCommand);
        bool DeleteEmployee(int id);
        bool EditEmployee(int id, EmployeeCommandModel employeeCommand);
    }
}
