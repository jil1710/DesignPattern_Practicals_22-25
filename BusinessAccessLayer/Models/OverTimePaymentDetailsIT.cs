using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models
{
    public class OverTimePaymentDetailsIT: IOverTimePaymentDetails
    {
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
