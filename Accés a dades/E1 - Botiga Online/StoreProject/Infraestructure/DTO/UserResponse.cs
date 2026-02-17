using StoreProject.Infraestructure.Persistance.Entities;

namespace SpotifyAPI.DTO;

public record UserResponse(Guid Id, string Username, string Email)
{
    public static UserResponse FromUser(User user)
    {
        return new UserResponse(user.Id, user.Username, user.Email);
    }
}
