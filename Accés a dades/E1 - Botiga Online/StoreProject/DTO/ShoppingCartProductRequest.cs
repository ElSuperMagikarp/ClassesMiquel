using StoreProject.Model;

namespace StoreProject.DTO;

public record ShoppingCartProductRequest(Guid shoppingCartId, Guid productId)
{
    public ShoppingCartProduct ToShoppingCartProduct(Guid id)
    {
        return new ShoppingCartProduct
        {
            Id = id,
            ShoppingCartId = shoppingCartId,
            ProductId = productId
        };
    }
}