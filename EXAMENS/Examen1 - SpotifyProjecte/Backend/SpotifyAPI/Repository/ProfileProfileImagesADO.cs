using Microsoft.Data.SqlClient;
using SpotifyAPI.Model;
using SpotifyAPI.Services;

namespace SpotifyAPI.Repository;

static class ProfileProfileImagesADO
{
    public static void Insert(SpotifyDBConnection dbConn, ProfileProfileImages profileProfileImages)
    {
        dbConn.Open();

        string sql = @"INSERT INTO ProfileProfileImages (Id, ProfileId, ProfileImageId)
                      VALUES (@Id, @ProfileId, @ProfileImageId)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", profileProfileImages.Id);
        cmd.Parameters.AddWithValue("@ProfileId", profileProfileImages.ProfileId);
        cmd.Parameters.AddWithValue("@ProfileImageId", profileProfileImages.ProfileImageId);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");

        dbConn.Close();
    }

    public static bool Delete(SpotifyDBConnection dbConn, Guid profileId, Guid profileImageId)
    {
        dbConn.Open();

        string sql = @"DELETE FROM ProfileProfileImages
                            WHERE ProfileId = @ProfileId
                            AND ProfileImageId = @ProfileImageId";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ProfileId", profileId);
        cmd.Parameters.AddWithValue("@ProfileImageId", profileImageId);

        int rows = cmd.ExecuteNonQuery();

        dbConn.Close();

        return rows > 0;
    }
}