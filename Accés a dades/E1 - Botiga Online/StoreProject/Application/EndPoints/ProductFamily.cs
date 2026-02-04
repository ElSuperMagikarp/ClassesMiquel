using StoreProject.Infraestructure.DTO;
using StoreProject.Infraestructure.Persistance.Entities;
using StoreProject.Infraestructure.Persistance.Repository;
using StoreProject.Infraestructure.Services;

namespace StoreProject.Application.EndPoints;

public static class ProductFamiliesEndpoints
{
    public static void MapProductFamilyEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // POST /productfamilies
        app.MapPost("/productfamilies", (ProductFamilyRequest req) =>
        {
            ProductFamily productFamily = new ProductFamily
            {
                Id = Guid.NewGuid(),
                Name = req.Name
            };

            ProductFamilyADO.Insert(dbConn, productFamily);

            return Results.Created($"/productfamilies/{productFamily.Id}", ProductFamilyResponse.FromProductFamily(productFamily));
        });

        // GET /productfamilies
        app.MapGet("/productfamilies", () =>
        {
            List<ProductFamily> productFamilies = ProductFamilyADO.GetAll(dbConn);
            List<ProductFamilyResponse> productFamilyResponses = new List<ProductFamilyResponse>();
            foreach (ProductFamily productFamily in productFamilies)
            {
                productFamilyResponses.Add(ProductFamilyResponse.FromProductFamily(productFamily));
            }
            return Results.Ok(productFamilyResponses);
        });

        // GET Product Family by id
        app.MapGet("/productfamilies/{id}", (Guid id) =>
        {
            ProductFamily? productFamily = ProductFamilyADO.GetById(dbConn, id);

            return productFamily is not null
                ? Results.Ok(ProductFamilyResponse.FromProductFamily(productFamily))
                : Results.NotFound(new { message = $"Product Family with Id {id} not found." });
        });

        // PUT Product Family
        app.MapPut("/productfamilies/{id}", (Guid id, ProductFamilyRequest req) =>
        {
            ProductFamily? productFamily = ProductFamilyADO.GetById(dbConn, id);

            if (productFamily == null)
            {
                return Results.NotFound();
            }

            ProductFamily productFamilyUpdt = new ProductFamily
            {
                Id = id,
                Name = req.Name
            };

            ProductFamilyADO.Update(dbConn, productFamilyUpdt);

            return Results.Ok(ProductFamilyResponse.FromProductFamily(productFamily));
        });

        // DELETE Product Family
        app.MapDelete("/productfamilies/{id}", (Guid id) => ProductFamilyADO.Delete(dbConn, id) ? Results.NoContent() : Results.NotFound());
    }
}