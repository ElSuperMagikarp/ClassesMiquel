using SpotifyAPI.Model;

namespace SpotifyAPI.DTO;

public record ProfileResponse(Guid Id, string Name, string? Description, bool IsActive)
{
    public static ProfileResponse FromProfile(Profile profile)
    {
        return new ProfileResponse(profile.Id, profile.Name, profile.Description, profile.IsActive);
    }
}