using SpotifyAPI.Model;

namespace SpotifyAPI.DTO;

public record ProfileRequest(string Name, string Description, bool IsActive)
{
    public Profile ToProfile(Guid id)
    {
        return new Profile
        {
            Id = id,
            Name = Name,
            Description = Description,
            IsActive = IsActive
        };
    }
}