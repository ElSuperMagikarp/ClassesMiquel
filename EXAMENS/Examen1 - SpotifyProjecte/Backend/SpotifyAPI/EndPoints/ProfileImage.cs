using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Model;
using SpotifyAPI.Repository;
using SpotifyAPI.Services;
using SpotifyAPI.Utils;

namespace SpotifyAPI.EndPoints;

public static class ProfileImageEndpoints
{
    public static void MapProfileImageEndpoints(this WebApplication app, SpotifyDBConnection dbConn)
    {
        // POST /profileImages
        app.MapPost("/profileImages", ([FromForm] IFormFileCollection files) =>
        {
            IFormFile[] filesArray = files.ToArray();
            if (filesArray == null)
                return Results.BadRequest(new { message = "No files recieved", files });

            FileHandler.InsertImageFiles(dbConn, filesArray);

            return Results.Ok(new { message = "Files successfully uploaded", files });
        })
        .Accepts<IFormFile[]>("multipart/form-data")
        .DisableAntiforgery();

        // DELETE /profileImages
        app.MapDelete("/profileImages/{id}", (Guid id) =>
        {

            ProfileImage? profileImage = ProfileImageADO.GetById(dbConn, id);
            if (profileImage is null)
                return Results.NotFound(new { message = $"Profile Image with Id {id} not found." });


            bool fileErased = FileHandler.DeleteFile(profileImage.Url);
            if (!fileErased)
                return Results.NotFound(new { message = $"Profile Image with url {profileImage.Url} not found." });

            ProfileImageADO.Delete(dbConn, id);

            return Results.Ok(new { message = "File successfully deleted", profileImage });
        });
    }
}