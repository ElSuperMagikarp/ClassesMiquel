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
                UserId = req.UserId,
                Name = req.Name,
                Description = req.Description,
                IsActive = req.IsActive
            };

            ProfileADO.Insert(dbConn, profile);

            return Results.Created($"/profiles/{profile.Id}", ProfileResponse.FromProfile(profile));
        });

        // GET /profiles
        app.MapGet("/profiles", () =>
        {
            List<Profile> profiles = ProfileADO.GetAll(dbConn);
            List<ProfileResponse> profileResponses = new List<ProfileResponse>();
            foreach (Profile profile in profiles)
            {
                profileResponses.Add(ProfileResponse.FromProfile(profile));
            }
            return Results.Ok(profileResponses);
        });

        // GET /profiles by id
        app.MapGet("/profiles/{id}", (Guid id) =>
        {
            Profile? profile = ProfileADO.GetById(dbConn, id);

            return profile is not null
                ? Results.Ok(ProfileResponse.FromProfile(profile))
                : Results.NotFound(new { message = $"Profile with Id {id} not found." });
        });

        // PUT /profiles (NO FUNCIONA I NO SE PERQUE)
        app.MapPut("/profiles/{id}", (Guid id, ProfileRequest req) =>
        {
            Profile? existing = ProfileADO.GetById(dbConn, id);

            if (existing == null)
            {
                return Results.NotFound();
            }

            Profile updated = new Profile
            {
                Id = id,
                UserId = req.UserId,
                Name = req.Name,
                Description = req.Description,
                IsActive = req.IsActive
            };

            ProfileADO.Update(dbConn, updated);

            return Results.Ok(ProfileResponse.FromProfile(updated));
        });

        // DELETE /profiles
        app.MapDelete("/profiles/{id}", (Guid id) => ProfileADO.Delete(dbConn, id) ? Results.NoContent() : Results.NotFound());

        // POST afegir ProfileImage a Profile
        app.MapPost("/profiles/{profileId}/profileImage/{profileImageId}", (Guid profileId, Guid profileImageId) =>
        {
            ProfileProfileImages profileProfileImages = new ProfileProfileImages
            {
                Id = Guid.NewGuid(),
                ProfileId = profileId,
                ProfileImageId = profileImageId
            };

            ProfileProfileImagesADO.Insert(dbConn, profileProfileImages);

            return Results.Created($"/profiles/{profileId}", profileProfileImages);
        });

        // DELETE treure Imatge de perfil
        app.MapDelete("/profiles/{profileId}/profileImage/{profileImageId}", (Guid profileId, Guid profileImageId) => ProfileProfileImagesADO.Delete(dbConn, profileId, profileImageId) ? Results.NoContent() : Results.NotFound());
    }
}