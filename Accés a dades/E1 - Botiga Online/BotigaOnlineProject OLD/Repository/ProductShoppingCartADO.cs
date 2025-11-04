using Microsoft.Data.SqlClient;
using botiga.Services;
using botiga.Model;

namespace botiga.Repository;

static class ProductShoppingCartADO
{
    public static void AddProduct(DatabaseConnection dbConn, ShoppingCart shoppingCart, Product product, int quantity)
    {
        dbConn.Open();

        string sql = @"";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", product.Id);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");
        dbConn.Close();
    }

    public static void RemoveProduct(DatabaseConnection dbConn, ShoppingCart shoppingCart, Product product, int quantity)
    {

    }
}