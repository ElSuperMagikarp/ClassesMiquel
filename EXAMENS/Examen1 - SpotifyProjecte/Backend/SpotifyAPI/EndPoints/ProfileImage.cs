using Microsoft.AspNetCore.Mvc;

using SpotifyAPI.Services;

namespace SpotifyAPI.EndPoints;

public static class ProfileImageEndpoints
{
    public static void MapProfileImageEndpoints(this WebApplication app, SpotifyDBConnection dbConn)
    {
        // POST /profileImages
        app.MapPost("/profileImages", ([FromForm] IFormFileCollection files) =>
        {

        })
        .Accepts<IFormFile[]>("multipart/form-data")
        .DisableAntiforgery();
    }
}