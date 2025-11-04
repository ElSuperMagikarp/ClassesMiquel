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
}