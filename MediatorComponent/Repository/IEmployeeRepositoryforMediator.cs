using MediatorComponent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorComponent.Repository
{
    public interface IEmployeeRepositoryforMediator
    {
        Task<Employee> GetById(int id);
        Task<bool> AddAsync(Employee employee);
        Task<bool> UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(int id);
    }
}
