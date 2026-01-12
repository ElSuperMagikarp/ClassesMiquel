using Microsoft.Data.SqlClient;
using StoreProject.Model;
using StoreProject.Services;

namespace StoreProject.Repository;

static class ShoppingCartProductADO
{
    public static void Insert(DatabaseConnection dbConn, ShoppingCartProduct shoppingCartProduct)
    {
        dbConn.Open();

        string sql = @"INSERT INTO ShoppingCartsProducts (Id, ShoppingCartId, ProductId, Quantity)
                        VALUES (@Id, @ShoppingCartId, @ProductId, @Quantity)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", shoppingCartProduct.Id);
        cmd.Parameters.AddWithValue("@ShoppingCartId", shoppingCartProduct.ShoppingCartId);
        cmd.Parameters.AddWithValue("@ProductId", shoppingCartProduct.ProductId);
        cmd.Parameters.AddWithValue("@Quantity", shoppingCartProduct.Quantity);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");
        dbConn.Close();
    }

    public static bool Delete(DatabaseConnection dbConn, Guid id)
    {
        dbConn.Open();

        string sql = @"DELETE FROM ShoppingCartsProducts WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        int rows = cmd.ExecuteNonQuery();

        dbConn.Close();

        return rows > 0;
    }
}