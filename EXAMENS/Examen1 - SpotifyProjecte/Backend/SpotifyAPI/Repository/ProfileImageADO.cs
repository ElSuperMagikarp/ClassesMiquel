using Microsoft.Data.SqlClient;

using SpotifyAPI.Model;
using SpotifyAPI.Services;

namespace SpotifyAPI.Repository;

static class ProfileImageADO
{
    public static void Insert(SpotifyDBConnection dbConn, ProfileImage profileImage)
    {
        dbConn.Open();

        string sql = @"INSERT INTO ProfilesImages (Id, Url)
                    VALUES (@Id, @Url)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", profileImage.Id);
        cmd.Parameters.AddWithValue("@Url", profileImage.Url);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");

        dbConn.Close();
    }

    public static ProfileImage? GetById(SpotifyDBConnection dbConn, Guid id)
    {
        dbConn.Open();
        string sql = "SELECT Id, Url FROM ProfilesImages WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        using SqlDataReader reader = cmd.ExecuteReader();
        ProfileImage? profileImage = null;

        if (reader.Read())
        {
            profileImage = new ProfileImage
            {
                Id = reader.GetGuid(0),
                Url = reader.GetString(1)
            };
        }

        dbConn.Close();
        return profileImage;
    }

    public static bool Delete(SpotifyDBConnection dbConn, Guid id)
    {
        dbConn.Open();

        string sql = @"DELETE FROM ProfilesImages WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        int rows = cmd.ExecuteNonQuery();

        dbConn.Close();

        return rows > 0;
    }
}