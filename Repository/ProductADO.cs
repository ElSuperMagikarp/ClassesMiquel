using Microsoft.Data.SqlClient;
using StoreProject.Services;
using StoreProject.Model;

namespace StoreProject.Repository;

static class ProductADO
{

    public static void Insert(DatabaseConnection dbConn, Product product)
    {
        dbConn.Open();

        string sql = @"INSERT INTO Products (Id, FamilyId, Code, Name, Price)
                        VALUES (@Id, @FamilyId, @Code, @Name, @Price)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", product.Id);
        cmd.Parameters.AddWithValue("@FamilyId", product.FamilyId);
        cmd.Parameters.AddWithValue("@Code", product.Code);
        cmd.Parameters.AddWithValue("@Name", product.Name);
        cmd.Parameters.AddWithValue("@Price", product.Price);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");
        dbConn.Close();
    }

    public static List<Product> GetAll(DatabaseConnection dbConn)
    {
        List<Product> products = new();

        dbConn.Open();
        string sql = "SELECT Id, FamilyId, Code, Name, Price FROM Products";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            products.Add(new Product
            {
                Id = reader.GetGuid(0),
                FamilyId = reader.GetGuid(1),
                Code = reader.GetString(2),
                Name = reader.GetString(3),
                Price = reader.GetDecimal(4)
            });
        }

        dbConn.Close();
        return products;
    }

    public static Product? GetById(DatabaseConnection dbConn, Guid id)
    {
        dbConn.Open();
        string sql = "SELECT Id, FamilyId, Code, Name, Price FROM Products WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        using SqlDataReader reader = cmd.ExecuteReader();
        Product? product = null;

        if (reader.Read())
        {
            product = new Product
            {
                Id = reader.GetGuid(0),
                FamilyId = reader.GetGuid(1),
                Code = reader.GetString(2),
                Name = reader.GetString(3),
                Price = reader.GetDecimal(4)
            };
        }

        dbConn.Close();
        return product;
    }

    public static void Update(DatabaseConnection dbConn, Product product)
    {
        dbConn.Open();

        string sql = @"UPDATE Products
                    SET FamilyId = @FamilyId,
                        Code = @Code,
                        Name = @Name,
                        Price = @Price
                    WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", product.Id);
        cmd.Parameters.AddWithValue("@FamilyId", product.FamilyId);
        cmd.Parameters.AddWithValue("@Code", product.Code);
        cmd.Parameters.AddWithValue("@Name", product.Name);
        cmd.Parameters.AddWithValue("@Price", product.Price);

        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine($"{rows} fila actualitzada.");

        dbConn.Close();
    }

    public static bool Delete(DatabaseConnection dbConn, Guid id)
    {
        dbConn.Open();

        string sql = @"DELETE FROM Products WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        int rows = cmd.ExecuteNonQuery();

        dbConn.Close();

        return rows > 0;
    }
}