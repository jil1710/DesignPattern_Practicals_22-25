using BusinessAccessLayer;
using CQRSPattern.DataConnection;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace DesignPatternPracticals.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("2.0")]
    public class FactoryPatternController : Controller
    {
        private readonly IConfiguration configuration;

        public FactoryPatternController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        [MapToApiVersion("2.0")]
        public IActionResult GetOvertimePayment(int id, int hours)
        {
            string conString = configuration.GetConnectionString("Default")!;

            string dept = "";
            using (var con = new SqlConnection(conString))
            {
                con.Open();
                var da = new SqlDataAdapter($"SELECT d.DepartmentName FROM Employee e JOIN Department d ON d.DepartmentId = e.DepartmentId WHERE e.DepartmentId=d.DepartmentId AND e.Id={id}; ", con);
                var dt = new DataTable();
                da.Fill(dt);

                
                if (dt.Rows.Count > 0)
                    dept = dt.Rows[0][0].ToString();
            }

            var employeeObj = EmployeeFactory.CreateEmployee(dept);
            if(employeeObj != null)
            {
                var overTimeTotal = employeeObj.OvertimePayment(hours);
                return Ok(new { employeeObj.Department, overTimeTotal });
            }
            return BadRequest(new {error = "Enter valid employee id"});
        }
    }
}
