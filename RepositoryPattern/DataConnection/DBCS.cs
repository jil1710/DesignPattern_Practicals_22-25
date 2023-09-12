namespace RepositoryPattern.DataConnection;

public static class DBCS
{
    public static string ConnectionString()
    {
        return "Data Source=SF-CPU-312\\SQLEXPRESS;Initial Catalog=Employee;User ID=abc;Password=123123;Connect Timeout=30;Encrypt=False";
    }
}
