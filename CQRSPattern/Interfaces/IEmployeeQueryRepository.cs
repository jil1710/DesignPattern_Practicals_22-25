using CQRSPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSPattern.Interfaces
{
    public interface IEmployeeQueryRepository
    {
        List<EmployeeQueryModel> GetAll();

        EmployeeQueryModel GetById(int id);
    }
}
