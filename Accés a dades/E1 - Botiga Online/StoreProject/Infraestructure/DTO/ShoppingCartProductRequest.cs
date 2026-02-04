using StoreProject.Model;

namespace StoreProject.Infraestructure.DTO;

public record ShoppingCartProductRequest(Guid shoppingCartId, Guid productId, int quantity)
{
    public ShoppingCartProduct ToShoppingCartProduct(Guid id)
    {
        return new ShoppingCartProduct
        {
            Id = id,
            ShoppingCartId = shoppingCartId,
            ProductId = productId,
            Quantity = quantity
        };
    }
}