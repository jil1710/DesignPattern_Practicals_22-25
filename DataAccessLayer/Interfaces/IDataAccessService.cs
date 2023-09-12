using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IDataAccessService
    {
        List<Employee> GetAllEmployees(int? id);

        bool CreateEmployee(Employee employee);

        bool EditEmployee(int id, Employee employee);

        bool DeleteEmployee(int id);
    }
}
