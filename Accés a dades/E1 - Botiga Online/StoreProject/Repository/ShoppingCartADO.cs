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