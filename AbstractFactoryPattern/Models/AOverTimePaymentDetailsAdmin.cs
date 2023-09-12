using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryPattern.Interfaces;

namespace BusinessAccessLayer.Models
{
    public class AOverTimePaymentDetailsAdmin: IIndoorOverTimePaymentDetails
    {
        public string DepartmentType { get; set; } = "Indoor";
        public string Department { get; set; } = "Admin";
        public decimal OvertimePayment(int hours)
        {
            return hours * 300;
        }
    }
}
