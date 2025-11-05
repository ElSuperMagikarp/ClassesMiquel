using SpotifyAPI.Model;

namespace SpotifyAPI.DTO;

public record ProfileRequest(Guid UserId, string Name, string Description, bool IsActive)
{
    public Profile ToProfile(Guid id)
    {
        return new Profile
        {
            Id = id,
            UserId = UserId,
            Name = Name,
            Description = Description,
            IsActive = IsActive
        };
    }
}