using Microsoft.Data.SqlClient;

using StoreProject.Model;
using StoreProject.Services;

namespace StoreProject.Repository;

static class ShoppingCartADO
{
    public static void Insert(DatabaseConnection dbConn, ShoppingCart shoppingCart)
    {
        dbConn.Open();

        string sql = @"INSERT INTO ShoppingCarts (Id)
                        VALUES (@Id)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", shoppingCart.Id);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");
        dbConn.Close();
    }

    public static List<ShoppingCartProduct> GetShoppingCartProducts(DatabaseConnection dbConn, Guid shoppingCartId)
    {
        List<ShoppingCartProduct> shoppingCartProducts = new();

        dbConn.Open();
        string sql = @"SELECT Id, ShoppingCartId, ProductId, Quantity FROM ShoppingCartsProducts
                        WHERE ShoppingCartId = @ShoppingCartId";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ShoppingCartId", shoppingCartId);

        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            shoppingCartProducts.Add(new ShoppingCartProduct
            {
                Id = reader.GetGuid(0),
                ShoppingCartId = reader.GetGuid(1),
                ProductId = reader.GetGuid(2),
                Quantity = reader.GetInt32(3)
            });
        }

        dbConn.Close();
        return shoppingCartProducts;
    }

    public static bool Delete(DatabaseConnection dbConn, Guid id)
    {
        dbConn.Open();

        string sql = @"DELETE FROM ShoppingCarts WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        int rows = cmd.ExecuteNonQuery();

        dbConn.Close();

        return rows > 0;
    }
}