using StoreProject.Repository;
using StoreProject.Services;
using StoreProject.Model;
using StoreProject.DTO;

namespace StoreProject.EndPoints;

public static class ShoppingCartProductEndpoints
{
    public static void MapShoppingCartProductEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // POST afegir Product a ShoppingCart
        app.MapPost("/shoppingCartProducts", (ShoppingCartProductRequest req) =>
        {
            ShoppingCartProduct shoppingCartProduct = new ShoppingCartProduct
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = req.shoppingCartId,
                ProductId = req.productId,
                Quantity = req.quantity
            };

            ShoppingCartProductADO.Insert(dbConn, shoppingCartProduct);

            return Results.Created($"/shoppingCarts/{shoppingCartProduct.Id}", ShoppingCartProductResponse.FromShoppingCartProduct(shoppingCartProduct));
        });

        // DELETE Treure Product de ShoppingCart
        app.MapDelete("/shoppingCartProducts/{id}", (Guid id) => ShoppingCartProductADO.Delete(dbConn, id) ? Results.NoContent() : Results.NotFound());
    }
}