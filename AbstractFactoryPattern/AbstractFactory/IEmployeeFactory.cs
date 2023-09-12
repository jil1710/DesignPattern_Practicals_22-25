using AbstractFactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactory
{
    public interface IEmployeeFactory
    {
        dynamic GetEmployeeObject(string departmentName);
    }
}
