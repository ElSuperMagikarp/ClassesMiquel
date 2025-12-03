using StoreProject.Model;

namespace StoreProject.DTO;

public record ShoppingCartProductResponse(Guid Id, Guid shoppingCartId, Guid productId)
{
    public static ShoppingCartProductResponse FromShoppingCartProduct(ShoppingCartProduct shoppingCartProduct)
    {
        return new ShoppingCartProductResponse(shoppingCartProduct.Id, shoppingCartProduct.ShoppingCartId, shoppingCartProduct.ProductId);
    }
}