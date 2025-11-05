using SpotifyAPI.Model;

namespace SpotifyAPI.DTO;

public record ProfileResponse(Guid Id, Guid UserId, string Name, string? Description, bool IsActive)
{
    public static ProfileResponse FromProfile(Profile profile)
    {
        return new ProfileResponse(profile.Id, profile.UserId, profile.Name, profile.Description, profile.IsActive);
    }
}