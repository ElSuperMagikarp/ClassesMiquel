using Microsoft.Data.SqlClient;
using StoreProject.Services;
using StoreProject.Infraestructure.Persistance.Entities;

namespace StoreProject.Infraestructure.Persistance.Repository;

static class ProductADO
{

    public static void Insert(DatabaseConnection dbConn, Product product)
    {
        dbConn.Open();

        string sql = @"INSERT INTO Products (Id, FamilyId, Code, Name, Price, Discount)
                        VALUES (@Id, @FamilyId, @Code, @Name, @Price, @Discount)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", product.Id);
        cmd.Parameters.AddWithValue("@FamilyId", product.FamilyId);
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
        List<Product> products = new();

        dbConn.Open();
        string sql = "SELECT Id, FamilyId, Code, Name, Price, Discount FROM Products";

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
                Price = reader.GetDecimal(4),
                Discount = reader.GetDecimal(5)
            });
        }

        dbConn.Close();
        return products;
    }

    public static Product? GetById(DatabaseConnection dbConn, Guid id)
    {
        dbConn.Open();
        string sql = "SELECT Id, FamilyId, Code, Name, Price, Discount FROM Products WHERE Id = @Id";

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
                Price = reader.GetDecimal(4),
                Discount = reader.GetDecimal(5)
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
                        Price = @Price,
                        Discount = @Discount
                    WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", product.Id);
        cmd.Parameters.AddWithValue("@FamilyId", product.FamilyId);
        cmd.Parameters.AddWithValue("@Code", product.Code);
        cmd.Parameters.AddWithValue("@Name", product.Name);
        cmd.Parameters.AddWithValue("@Price", product.Price);
        cmd.Parameters.AddWithValue("@Discount", product.Discount);

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

    public static bool CodeExists(DatabaseConnection dbConn, string code)
    {
        dbConn.Open();
        string sql = "SELECT COUNT(*) FROM Products WHERE Code = @Code";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Code", code);

        int count = (int)cmd.ExecuteScalar();

        dbConn.Close();

        return count > 0;
    }

    public static bool NameExists(DatabaseConnection dbConn, string name)
    {
        dbConn.Open();
        string sql = "SELECT COUNT(*) FROM Products WHERE Name = @Name";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Name", name);

        int count = (int)cmd.ExecuteScalar();

        dbConn.Close();

        return count > 0;
    }
}