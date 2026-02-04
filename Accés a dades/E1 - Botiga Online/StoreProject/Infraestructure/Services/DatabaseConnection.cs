using Microsoft.Data.SqlClient;

namespace StoreProject.Infraestructure.Services;

public class DatabaseConnection
{
    private readonly string _connectionString;
    public SqlConnection sqlConnection;
    public DatabaseConnection(string connectionString)
    {
        _connectionString = connectionString;
    }
    public bool Open()
    {
        sqlConnection = new SqlConnection(_connectionString);

        try
        {
            sqlConnection.Open();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to database: {ex.Message}");
            return false;
        }
    }
    public void Close()
    {
        sqlConnection.Close();
    }
}