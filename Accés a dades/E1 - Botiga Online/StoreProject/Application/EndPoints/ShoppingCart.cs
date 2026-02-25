using StoreProject.Infraestructure.Persistance.Repository;
using StoreProject.Infraestructure.Services;
using StoreProject.Infraestructure.Persistance.Entities;
using StoreProject.Helpers;
using StoreProject.Infraestructure.Classes.Interfaces;
using StoreProject.Infraestructure.Classes.Factories;
using StoreProject.Infraestructure.DTO;
using StoreProject.Domain.Entities;
using StoreProject.Infraestructure.Common;
using StoreProject.Validators;

namespace StoreProject.Application.EndPoints;

public static class ShoppingCartEndpoints
{
    public static void MapShoppingCartEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // POST /shoppingCart
        app.MapPost("/shoppingCarts", (ShoppingCartRequest req) =>
        {
            Guid id = Guid.NewGuid();

            ShoppingCart shoppingCart = req.ToShoppingCart(id);
            ShoppingCartADO.Insert(dbConn, shoppingCart);

            return Results.Created($"/shoppingCarts/{shoppingCart.Id}", shoppingCart);
        });

        // DELETE ShoppingCart
        app.MapDelete("/shoppingCarts/{id}", (Guid id) => ShoppingCartADO.Delete(dbConn, id) ? Results.NoContent() : Results.NotFound());

        // GET IMPORT
        app.MapGet("shoppingCarts/{id}/import", (Guid id, string discountType = "regular") =>
        {
            List<Infraestructure.Classes.ShoppingCartProduct> shoppingCartProducts = ShoppingCartADO.GetShoppingCartProducts(dbConn, id);

            decimal baseImport = ShoppingCartCalculations.CalculateImport(shoppingCartProducts);

            IDiscountFactory factory = discountType switch
            {
                "regular" => new RegularDiscountFactory(),
                "premium" => new PremiumDiscountFactory(),
                _ => throw new ArgumentException("Tipus de descompte desconegut.")
            };
            IDiscount discountCalculator = factory.CreateDiscount();

            decimal discount = discountCalculator.calculateDiscount(baseImport) / 100;

            decimal import = baseImport * (1 - discount);

            return Results.Ok(new { import });
        });

        app.MapPost("shoppingCarts/purchase", (PurchaseRequest req) =>
        {
            Purchase purchase = req.ToPurchase();
            Result result = PurchaseValidator.Validate(req);
            if (!result.IsOk)
            {
                return Results.BadRequest(new
                {
                    error = result.ErrorCode,
                    message = result.ErrorMessage
                });
            }

            return Results.Ok(purchase);
        });
    }
}