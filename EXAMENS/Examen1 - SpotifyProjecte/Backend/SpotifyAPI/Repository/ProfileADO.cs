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

    public static List<Profile> GetAll(SpotifyDBConnection dbConn)
    {
        List<Profile> profiles = new();

        dbConn.Open();
        string sql = "SELECT Id, UserId, Name, Description, IsActive FROM Profiles";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            profiles.Add(new Profile
            {
                Id = reader.GetGuid(0),
                UserId = reader.GetGuid(1),
                Name = reader.GetString(2),
                Description = reader.GetString(3),
                IsActive = reader.GetBoolean(4)
            });
        }

        dbConn.Close();
        return profiles;
    }

    public static Profile? GetById(SpotifyDBConnection dbConn, Guid id)
    {
        dbConn.Open();
        string sql = "SELECT Id, UserId, Name, Description, IsActive FROM Profiles WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        using SqlDataReader reader = cmd.ExecuteReader();
        Profile? profile = null;

        if (reader.Read())
        {
            profile = new Profile
            {
                Id = reader.GetGuid(0),
                UserId = reader.GetGuid(1),
                Name = reader.GetString(2),
                Description = reader.GetString(3),
                IsActive = reader.GetBoolean(4)
            };
        }

        dbConn.Close();
        return profile;
    }

    public static void Update(SpotifyDBConnection dbConn, Profile profile)
    {
        dbConn.Open();

        string sql = @"UPDATE Profiles SET
                    UserId = @UserId
                    Name = @Name,
                    Description = @Description
                    IsActive = @IsActive
                    WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", profile.Id);
        cmd.Parameters.AddWithValue("@UserId", profile.UserId);
        cmd.Parameters.AddWithValue("@Name", profile.Name);
        cmd.Parameters.AddWithValue("@Description", profile.Description);
        cmd.Parameters.AddWithValue("@IsActive", profile.IsActive);

        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine($"{rows} files actualitzades");

        dbConn.Close();
    }

    public static bool Delete(SpotifyDBConnection dbConn, Guid id)
    {
        dbConn.Open();

        string sql = @"DELETE FROM Profiles WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        int rows = cmd.ExecuteNonQuery();

        dbConn.Close();

        return rows > 0;
    }
}