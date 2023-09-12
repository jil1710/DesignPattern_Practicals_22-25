namespace AbstractFactoryPattern.Interfaces
{
    public interface IIndoorOverTimePaymentDetails
    {
        string DepartmentType { get; set; }
        string Department { get; set; }
        decimal OvertimePayment(int hours);
    }
}
