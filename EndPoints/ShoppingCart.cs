using StoreProject.Repository;
using StoreProject.Services;
using StoreProject.Model;

namespace StoreProject.EndPoints;

public static class ShoppingCartEndpoints
{
    public static void MapShoppingCartEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // POST /shoppingCart
        app.MapPost("/shoppingCart", () =>
        {
            ShoppingCart shoppingCart = new ShoppingCart
            {
                Id = Guid.NewGuid()
            };

            ShoppingCartADO.Insert(dbConn, shoppingCart);

            return Results.Created($"/shoppingCart/{shoppingCart.Id}", shoppingCart);
        });
    }
}