using System.ComponentModel.DataAnnotations;

namespace MediatorComponent.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
    public int DepartmentId { get; set; }
    public string EmailId { get; set; }
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? JoiningDate { get; set; }
    public bool Status { get; set; }
}
