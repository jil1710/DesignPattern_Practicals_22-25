using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryPattern.Interfaces;

namespace BusinessAccessLayer.Models
{
    public class AOverTimePaymentDetailsIT: IIndoorOverTimePaymentDetails
    {
        public string DepartmentType { get; set; } = "Indoor";
        public string Department { get; set; } = "IT";

        //public int EmpId { get; set; }
        //public string EmpName { get; set; }
        //public string DepartmentName { get; set; }
        //public int OvertimeHours { get; set; }

        public decimal OvertimePayment(int hours)
        {
            return hours * 200;
        }
    }
}
