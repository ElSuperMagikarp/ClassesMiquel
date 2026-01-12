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

        // DELETE Treure Product de ShoppingCart
        app.MapDelete("/shoppingCarts/{id}", (Guid id) => ShoppingCartProductADO.Delete(dbConn, id) ? Results.NoContent() : Results.NotFound());
    }
}