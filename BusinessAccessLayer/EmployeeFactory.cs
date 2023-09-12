using BusinessAccessLayer.Models;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer
{
    public class EmployeeFactory
    {
        public static IOverTimePaymentDetails CreateEmployee(string departmentName)
        {
            switch (departmentName.ToUpper())
            {
                case "IT":
                    return new OverTimePaymentDetailsIT();
                case "ADMIN":
                    return new OverTimePaymentDetailsAdmin();
                case "HR":
                    return new OverTimePaymentDetailsHR();
                case "SALES":
                    return new OverTimePaymentDetailsSales();
                case "ON-SITE":
                    return new OverTimePaymentDetailsOnsite();
                default:
                    return null;
            }
        }
    }
}