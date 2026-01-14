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

        // shoppingCarts/{id}/import
        // GET IMPORT
        app.MapGet("shoppingCarts/{id}/import", (Guid id) =>
        {
            List<ShoppingCartProduct> shoppingCartProducts = ShoppingCartADO.GetShoppingCartProducts(dbConn, id);

            decimal import = 0;

            foreach (ShoppingCartProduct shoppingCartProduct in shoppingCartProducts)
            {
                Product product = ProductADO.GetById(dbConn, shoppingCartProduct.ProductId);
                decimal productDiscount = product.Discount / 100;
                import += product.Price * productDiscount * shoppingCartProduct.Quantity;
            }

            return Results.Ok(import);
        });
    }
}