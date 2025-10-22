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

    public static List<ProductFamily> GetAll(DatabaseConnection dbConn)
    {
        List<ProductFamily> productfamilies = new();

        dbConn.Open();
        string sql = "SELECT Id, Name FROM ProductFamilies";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            productfamilies.Add(new ProductFamily
            {
                Id = reader.GetGuid(0),
                Name = reader.GetString(1)
            });
        }

        dbConn.Close();
        return productfamilies;
    }
}

/*CREATE TABLE ProductFamilies (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);*/