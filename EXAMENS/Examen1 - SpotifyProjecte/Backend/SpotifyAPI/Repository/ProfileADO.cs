using Microsoft.Data.SqlClient;

using SpotifyAPI.Model;
using SpotifyAPI.Services;

namespace SpotifyAPI.Repository;

static class ProfileADO
{
    public static void Insert(SpotifyDBConnection dbConn, Profile profile)
    {
        dbConn.Open();

        string sql = @"INSERT INTO Profiles (Id, UserId, Name, Description, IsActive)
                    VALUES (@Id, @UserId, @Name, @Description, @IsActive)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", profile.Id);
        cmd.Parameters.AddWithValue("@UserId", profile.UserId);
        cmd.Parameters.AddWithValue("@Name", profile.Name);
        cmd.Parameters.AddWithValue("@Description", profile.Description);
        cmd.Parameters.AddWithValue("@IsActive", profile.IsActive);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");

        dbConn.Close();
    }
}