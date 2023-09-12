using DataAccessLayer.DataConnection;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Singleton;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer.Services
{
    public class DataAccessService : IDataAccessService
    {
        private readonly string conString = null;
        private readonly IConfiguration configuration;

        public DataAccessService(IConfiguration configuration)
        {
            this.configuration = configuration;
            conString = configuration.GetConnectionString("Default")!;
        }

        private Logger _logger = SingletonClass.GetLoggerInstance();

        public List<Employee> GetAllEmployees(int? id)
        {
            using (var con = new SqlConnection(conString))
            {
                con.Open();
                var da = new SqlDataAdapter("SELECT * FROM Employee;", con);
                if (id != null && id != 0)
                    da = new SqlDataAdapter($"SELECT * FROM Employee WHERE Id={id};", con);

                var dt = new DataTable();
                da.Fill(dt);

                var empList = new List<Employee>();
                foreach (DataRow emp in dt.Rows)
                {
                    var employee = new Employee()
                    {
                        Id = (int)emp[0],
                        Name = (string)emp[1],
                        DepartmentId = (int)emp[2],
                        EmailId = (string)emp[3],
                        Status = (bool)emp[4],
                        JoiningDate = (DateTime)emp[5],
                        Salary = (double)(decimal)emp[6],
                    };
                    empList.Add(employee);
                }
                _logger.Log($"Employee details retrieved with Id = {id}");
                return empList;
            }
        }

        public bool CreateEmployee(Employee employee)
        {
            if (employee != null)
            {
                using (var con = new SqlConnection(conString))
                {
                    con.Open();
                    var cmd = new SqlCommand("INSERT INTO Employee VALUES (@id,@name, @departmentid, @emailid, @status,@joiningdate,@salary);", con);
                    SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar, 40);
                    SqlParameter id = new SqlParameter("@id", SqlDbType.Int, 4000);
                    SqlParameter salary = new SqlParameter("@salary", SqlDbType.Money);
                    SqlParameter departmentid = new SqlParameter("@departmentid", SqlDbType.Int, 100);
                    SqlParameter emailid = new SqlParameter("@emailid", SqlDbType.VarChar, 255);
                    SqlParameter joiningdate = new SqlParameter("@joiningdate", SqlDbType.DateTime);
                    SqlParameter status = new SqlParameter("@status", SqlDbType.Bit);

                    id.Value = employee.Id;
                    name.Value = employee.Name;
                    salary.Value = employee.Salary;
                    departmentid.Value = employee.DepartmentId;
                    emailid.Value = employee.EmailId;
                    joiningdate.Value = employee.JoiningDate;
                    status.Value = employee.Status;

                    cmd.Parameters.Add(name);
                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add(salary);
                    cmd.Parameters.Add(departmentid);
                    cmd.Parameters.Add(emailid);
                    cmd.Parameters.Add(joiningdate);
                    cmd.Parameters.Add(status);

                    var response = cmd.ExecuteNonQuery();
                    if (response >= 1)
                    {
                        _logger.Log("Employee created successfully");
                        return true;
                    }
                    else
                    {
                        _logger.Log("Error in employee creation");
                        return false;
                    }
                }
            }
            _logger.Log("Error in employee creation");
            return false;
        }

        public bool EditEmployee(int id, Employee employee)
        {
            using(var con = new SqlConnection(conString))
            {
                con.Open();
                var cmd = new SqlCommand("UPDATE Employee SET Name=@name, Salary=@salary, DepartmentId=@departmentId, EmailId=@emailId, JoiningDate=@joiningDate, Status=@status WHERE Id=@Id;", con);
                
                SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar, 100);
                SqlParameter salary = new SqlParameter("@salary", SqlDbType.Money);
                SqlParameter departmentid = new SqlParameter("@departmentId", SqlDbType.Int, 100);
                SqlParameter emailid = new SqlParameter("@emailId", SqlDbType.VarChar, 50);
                SqlParameter joiningdate = new SqlParameter("@joiningDate", SqlDbType.Date);
                SqlParameter status = new SqlParameter("@status", SqlDbType.VarChar, 50);
                SqlParameter Id = new SqlParameter("Id", SqlDbType.Int);

                name.Value = employee.Name;
                salary.Value = employee.Salary;
                departmentid.Value = employee.DepartmentId;
                emailid.Value = employee.EmailId;
                joiningdate.Value = employee.JoiningDate;
                status.Value = employee.Status;
                Id.Value = id;

                cmd.Parameters.Add(name);
                cmd.Parameters.Add(salary);
                cmd.Parameters.Add(departmentid);
                cmd.Parameters.Add(emailid);
                cmd.Parameters.Add(joiningdate);
                cmd.Parameters.Add(status);
                cmd.Parameters.Add(Id);

                var editResult = cmd.ExecuteNonQuery();
                if (editResult == 1)
                {
                    _logger.Log($"Employee edited successfully with id = {id}");
                    return true;
                }
                _logger.Log("There is some error in employee edit process");
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            using (var con = new SqlConnection(conString))
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM Employee WHERE Id=@id;", con);
                SqlParameter empid = new SqlParameter("@id", SqlDbType.Int);
                empid.Value = id;
                cmd.Parameters.Add(empid);
                var deleteResult = cmd.ExecuteNonQuery();
                if (deleteResult == 1)
                {
                    _logger.Log($"Employee deleted successfully with id = {id}");
                    return true;
                }
                _logger.Log("There is some error occurred while deleting employee");
                return false;
            }
        }
    }
}