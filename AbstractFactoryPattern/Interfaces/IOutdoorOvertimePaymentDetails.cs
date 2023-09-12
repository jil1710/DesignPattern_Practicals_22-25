namespace AbstractFactoryPattern.Interfaces
{
    public interface IOutdoorOvertimePaymentDetails
    {
        string DepartmentType { get; set; }
        string Department { get; set; }
        decimal OvertimePayment(int hours);
    }
}
