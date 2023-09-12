using MediatorComponent.DataConnection;
using MediatorComponent.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MediatorComponent.Repository;

public class EmployeeRepositoryforMediator : IEmployeeRepositoryforMediator
{
    private readonly string conString = null;
    private readonly IConfiguration configuration;

    public EmployeeRepositoryforMediator(IConfiguration configuration)
    {
        this.configuration = configuration;
        conString = configuration.GetConnectionString("Default")!;
    }
    
    public async Task<Employee> GetById(int id)
    {
        using (var con = new SqlConnection(conString))
        {
            con.Open();
            var da = new SqlDataAdapter($"SELECT * FROM Employee WHERE Id={id};", con);

            var dt = new DataTable();
            da.Fill(dt);

            var employee = new Employee()
            {
                Id = (int)dt.Rows[0][0],
                Name = (string)dt.Rows[0][1],
                DepartmentId = (int)dt.Rows[0][2],
                EmailId = (string)dt.Rows[0][3],
                Status = (bool)dt.Rows[0][4],
                JoiningDate = (DateTime)dt.Rows[0][5],
                Salary = (double)(decimal)dt.Rows[0][6],
            };

            return employee;
        }
    }


    public async Task<bool> AddAsync(Employee employee)
    {
        if (employee != null)
        {
            using (var con = new SqlConnection(conString))
            {
                con.Open();
                var cmd = new SqlCommand("INSERT INTO Employee VALUES (@id,@name, @departmentid, @emailid, @status,@joiningdate,@salary);", con);
                SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar, 100);
                SqlParameter id = new SqlParameter("@id", SqlDbType.Int, 4000);
                SqlParameter salary = new SqlParameter("@salary", SqlDbType.Money);
                SqlParameter departmentid = new SqlParameter("@departmentid", SqlDbType.Int, 100);
                SqlParameter emailid = new SqlParameter("@emailid", SqlDbType.VarChar, 255);
                SqlParameter joiningdate = new SqlParameter("@joiningdate", SqlDbType.DateTime);
                SqlParameter status = new SqlParameter("@status", SqlDbType.Bit);

                name.Value = employee.Name;
                id.Value = employee.Id;
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
                    return true;
                return false;
            }
        }
        return false;
    }


    public async Task<bool> DeleteAsync(int id)
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
                return true;
            return false;
        }
    }


    public async Task<bool> UpdateAsync(Employee employee)
    {
        using (var con = new SqlConnection(conString))
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
            Id.Value = employee.Id;

            cmd.Parameters.Add(name);
            cmd.Parameters.Add(salary);
            cmd.Parameters.Add(departmentid);
            cmd.Parameters.Add(emailid);
            cmd.Parameters.Add(joiningdate);
            cmd.Parameters.Add(status);
            cmd.Parameters.Add(Id);

            var editResult = cmd.ExecuteNonQuery();
            if (editResult == 1)
                return true;
            return false;
        }
    }
}
