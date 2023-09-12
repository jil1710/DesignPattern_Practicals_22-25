using AbstractFactoryPattern.AbstractFactory;
using BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.ConcreteFactory
{
    public class OutdoorFactory: IEmployeeFactory
    {
        public dynamic GetEmployeeObject(string departmentName)
        {
            if (departmentName.ToUpper() == "SALES")
            {
                return new AOverTimePaymentDetailsSales();
            }
            else if (departmentName.ToUpper() == "ON-SITE")
            {
                return new AOverTimePaymentDetailsOnsite();
            }
            else
            {
                return null;
            }
        }
    }
}
