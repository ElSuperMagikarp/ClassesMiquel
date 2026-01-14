using Microsoft.Data.SqlClient;
using StoreProject.Model;
using StoreProject.Services;

namespace StoreProject.Repository;

static class ProductFamilyADO
{
    public static void Insert(DatabaseConnection dbConn, ProductFamily productFamily)
    {
        dbConn.Open();

        string sql = @"INSERT INTO ProductFamilies (Id, Name)
                        VALUES (@Id, @Name)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", productFamily.Id);
        cmd.Parameters.AddWithValue("@Name", productFamily.Name);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");
        dbConn.Close();
    }

    public static List<ProductFamily> GetAll(DatabaseConnection dbConn)
    {
        List<ProductFamily> productFamilies = new();

        dbConn.Open();
        string sql = "SELECT Id, Name FROM ProductFamilies";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            productFamilies.Add(new ProductFamily
            {
                Id = reader.GetGuid(0),
                Name = reader.GetString(1)
            });
        }

        dbConn.Close();
        return productFamilies;
    }

    public static ProductFamily? GetById(DatabaseConnection dbConn, Guid id)
    {
        dbConn.Open();
        string sql = "SELECT Id, Name FROM ProductFamilies WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        using SqlDataReader reader = cmd.ExecuteReader();
        ProductFamily? productFamily = null;

        if (reader.Read())
        {
            productFamily = new ProductFamily
            {
                Id = reader.GetGuid(0),
                Name = reader.GetString(1)
            };
        }

        dbConn.Close();
        return productFamily;
    }

    public static void Update(DatabaseConnection dbConn, ProductFamily productFamily)
    {
        dbConn.Open();

        string sql = @"UPDATE ProductFamilies
                    SET Name = @Name
                    WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", productFamily.Id);
        cmd.Parameters.AddWithValue("@Name", productFamily.Name);

        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine($"{rows} fila actualitzada.");

        dbConn.Close();
    }

    public static bool Delete(DatabaseConnection dbConn, Guid id)
    {
        dbConn.Open();

        string sql = @"DELETE FROM ProductFamilies WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        int rows = cmd.ExecuteNonQuery();

        dbConn.Close();

        return rows > 0;
    }

    public static bool ProductFamilyExists(DatabaseConnection dbConn, Guid id)
    {
        dbConn.Open();
        string sql = "SELECT * FROM ProductFamilies WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        int count = (int)cmd.ExecuteScalar();

        dbConn.Close();

        return count > 0;
    }
}