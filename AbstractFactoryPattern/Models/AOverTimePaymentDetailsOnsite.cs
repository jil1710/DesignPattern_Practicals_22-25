using AbstractFactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models
{
    public class AOverTimePaymentDetailsOnsite: IOutdoorOvertimePaymentDetails
    {
        public string DepartmentType { get; set; } = "Outdoor";
        public string Department { get; set; } = "On-site";
        public decimal OvertimePayment(int hours)
        {
            return hours * 500;
        }
    }
}
