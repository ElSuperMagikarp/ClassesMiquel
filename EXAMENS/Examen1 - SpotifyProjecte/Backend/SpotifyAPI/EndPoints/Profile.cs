using SpotifyAPI.DTO;
using SpotifyAPI.Model;
using SpotifyAPI.Repository;
using SpotifyAPI.Services;

namespace SpotifyAPI.EndPoints;

public static class ProfileEndpoints
{
    public static void MapProfileEndpoints(this WebApplication app, SpotifyDBConnection dbConn)
    {
        // POST /profiles
        app.MapPost("/profiles", (ProfileRequest req) =>
        {
            Profile profile = new Profile
            {
                Id = Guid.NewGuid(),
                Name = req.Name,
                Description = req.Description,
                IsActive = req.IsActive
            };

            ProfileADO.Insert(dbConn, profile);

            return Results.Created($"/profiles/{profile.Id}", ProfileResponse.FromProfile(profile));
        });
    }
}