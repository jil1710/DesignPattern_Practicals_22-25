using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models
{
    public class OverTimePaymentDetailsAdmin: IOverTimePaymentDetails
    {
        public string Department { get; set; } = "Admin";
        public decimal OvertimePayment(int hours)
        {
            return hours * 300;
        }
    }
}
