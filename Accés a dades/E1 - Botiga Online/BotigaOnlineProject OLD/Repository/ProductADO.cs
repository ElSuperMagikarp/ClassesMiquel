using Microsoft.Data.SqlClient;
using botiga.Services;
using botiga.Model;

namespace botiga.Repository;

static class ProductADO
{
    public static void Insert(DatabaseConnection dbConn, Product product)
    {
        dbConn.Open();

        string sql = @"INSERT INTO Products (Id, Code, Name, Price, Discount)
                        VALUES (@Id, @Code, @Name, @Price, @Discount)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", product.Id);
        cmd.Parameters.AddWithValue("@Code", product.Code);
        cmd.Parameters.AddWithValue("@Name", product.Name);
        cmd.Parameters.AddWithValue("@Price", product.Price);
        cmd.Parameters.AddWithValue("@Discount", product.Discount);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");
        dbConn.Close();
    }

    public static List<Product> GetAll(DatabaseConnection dbConn)
    {
        List<Product> productes = new();

        dbConn.Open();
        string sql = "SELECT Id, Code, Name, Price, Discount FROM Products";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            productes.Add(new Product
            {
                Id = reader.GetGuid(0),
                Code = reader.GetString(1),
                Name = reader.GetString(2),
                Price = reader.GetDecimal(3),
                Discount = reader.GetDecimal(4)
            });
        }

        dbConn.Close();
        return productes;
    }

    public static Product? GetById(DatabaseConnection dbConn, Guid id)
    {
        dbConn.Open();
        string sql = "SELECT Id, Code, Name, Price, Discount FROM Products WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        using SqlDataReader reader = cmd.ExecuteReader();
        Product? producte = null;

        if (reader.Read())
        {
            producte = new Product
            {
                Id = reader.GetGuid(0),
                Code = reader.GetString(1),
                Name = reader.GetString(2),
                Price = reader.GetDecimal(3),
                Discount = reader.GetDecimal(4)
            };
        }

        dbConn.Close();
        return producte;
    }
}