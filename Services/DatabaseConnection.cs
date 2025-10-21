using Microsoft.Data.SqlClient;
using static System.Console;
using StoreProject.Model;

namespace StoreProject.Services;

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
            return false;
        }
    }
    public void Close()
    {
        sqlConnection.Close();
    }
}