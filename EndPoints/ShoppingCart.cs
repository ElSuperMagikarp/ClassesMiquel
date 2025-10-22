using StoreProject.Repository;
using StoreProject.Services;
using StoreProject.Model;

namespace StoreProject.EndPoints;

public static class ShoppingCartEndpoints
{
    public static void MapShoppingCartEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // POST /shoppingCart
        app.MapPost("/shoppingCarts", () =>
        {
            ShoppingCart shoppingCart = new ShoppingCart
            {
                Id = Guid.NewGuid()
            };

            ShoppingCartADO.Insert(dbConn, shoppingCart);

            return Results.Created($"/shoppingCarts/{shoppingCart.Id}", shoppingCart);
        });

        // POST afegir Product a ShoppingCart
        app.MapPost("/shoppingCarts/{id}/add", (Guid id, ShoppingCartProductRequest req) =>
        {
            ShoppingCartProduct shoppingCartProduct = new ShoppingCartProduct
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = id,
                ProductId = req.ProductId
            };

            ShoppingCartProductADO.Insert(dbConn, shoppingCartProduct);

            return Results.Created($"/shoppingCarts/{id}", shoppingCartProduct);
        });

        // DELETE Treure Product de ShoppingCart
        app.MapDelete("/shoppingCarts/{id}/remove", (Guid id) => ShoppingCartProductADO.Delete(dbConn, id) ? Results.NoContent() : Results.NotFound());
    }
}

public record ShoppingCartProductRequest(Guid ProductId);  // Com ha de llegir el POST