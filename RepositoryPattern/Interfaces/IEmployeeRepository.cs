using RepositoryPattern.Models;

namespace RepositoryPattern.Interfaces
{
    public interface IEmployeeRepository
    {
        List<EmployeeR> GetAllEmployees(int? id);

        bool CreateEmployee(EmployeeR employee);

        bool EditEmployee(int id, EmployeeR employee);

        bool DeleteEmployee(int id);
    }
}
