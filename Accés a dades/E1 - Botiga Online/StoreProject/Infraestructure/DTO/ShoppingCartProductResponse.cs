using StoreProject.Model;

namespace StoreProject.Infraestructure.DTO;

public record ShoppingCartProductResponse(Guid Id, Guid shoppingCartId, Guid productId, int quantity)
{
    public static ShoppingCartProductResponse FromShoppingCartProduct(ShoppingCartProduct shoppingCartProduct)
    {
        return new ShoppingCartProductResponse(shoppingCartProduct.Id, shoppingCartProduct.ShoppingCartId, shoppingCartProduct.ProductId, shoppingCartProduct.Quantity);
    }
}