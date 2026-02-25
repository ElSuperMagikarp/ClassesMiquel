using StoreProject.Infraestructure.Persistance.Entities;

namespace StoreProject.Infraestructure.DTO;

public record ShoppingCartRequest(Guid UserId, DateOnly Date)
{
    public ShoppingCart ToShoppingCart(Guid id)
    {
        return new ShoppingCart
        {
            Id = id,
            UserId = UserId,
            Date = Date
        };
    }
}