using Microsoft.Data.SqlClient;
using botiga.Services;
using botiga.Model;

namespace botiga.Repository;

static class FamilyADO
{
    public static void Insert(DatabaseConnection dbConn, Family family)
    {
        dbConn.Open();

        string sql = @"INSERT INTO Families (Id, Name)
                        VALUES (@Id, @Name)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", family.Id);
        cmd.Parameters.AddWithValue("@Name", family.Name);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");
        dbConn.Close();
    }

    public static List<Family> GetAll(DatabaseConnection dbConn)
    {
        List<Family> families = new();

        dbConn.Open();
        string sql = "SELECT Id, Name FROM Families";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            families.Add(new Family
            {
                Id = reader.GetGuid(0),
                Name = reader.GetString(1),
            });
        }

        dbConn.Close();
        return families;
    }
}