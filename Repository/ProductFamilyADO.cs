using Microsoft.Data.SqlClient;
using StoreProject.Model;
using StoreProject.Services;

namespace StoreProject.Repository;

static class ProductFamilyADO
{
    public static void Insert(DatabaseConnection dbConn, ProductFamily family)
    {
        dbConn.Open();

        string sql = @"INSERT INTO ProductFamilies (Id, Name)
                        VALUES (@Id, @Name)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", family.Id);
        cmd.Parameters.AddWithValue("@Name", family.Name);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");
        dbConn.Close();
    }
}

/*CREATE TABLE ProductFamilies (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);*/