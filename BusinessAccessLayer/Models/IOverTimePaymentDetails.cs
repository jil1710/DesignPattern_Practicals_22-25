using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models
{
    public interface IOverTimePaymentDetails
    {
        public string Department { get; set; }
        public decimal OvertimePayment(int hours);
    }
}
