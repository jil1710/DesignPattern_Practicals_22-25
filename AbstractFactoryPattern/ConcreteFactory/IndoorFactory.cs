using AbstractFactoryPattern.AbstractFactory;
using BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.ConcreteFactory
{
    public class IndoorFactory : IEmployeeFactory
    {
        public dynamic GetEmployeeObject(string departmentName)
        {
            if(departmentName.ToUpper() == "IT")
            {
                return new AOverTimePaymentDetailsIT();
            }
            else if(departmentName.ToUpper() == "HR")
            {
                return new AOverTimePaymentDetailsHR();
            }
            else if(departmentName.ToUpper() == "ADMIN")
            {
                return new AOverTimePaymentDetailsAdmin();
            }
            else
            {
                return null;
            }
        }
    }
}
