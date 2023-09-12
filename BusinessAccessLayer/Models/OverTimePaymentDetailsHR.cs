using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models
{
    public class OverTimePaymentDetailsHR: IOverTimePaymentDetails
    {
        public string Department { get; set; } = "HR";
        public decimal OvertimePayment(int hours)
        {
            return hours * 150;
        }
    }
}
