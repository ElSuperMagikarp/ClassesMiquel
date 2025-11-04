using StoreProject.Model;
using StoreProject.Repository;
using StoreProject.Services;

namespace StoreProject.EndPoints;

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

            return Results.Created($"/productfamilies/{productFamily.Id}", productFamily);
        });

        // GET /productfamilies
        app.MapGet("/productfamilies", () =>
        {
            List<ProductFamily> productfamilies = ProductFamilyADO.GetAll(dbConn);
            return Results.Ok(productfamilies);
        });

        // GET Product Family by id
        app.MapGet("/productfamilies/{id}", (Guid id) =>
        {
            ProductFamily? productFamily = ProductFamilyADO.GetById(dbConn, id);

            return productFamily is not null
                ? Results.Ok(productFamily)
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

            return Results.Ok(productFamilyUpdt);
        });

        // DELETE Product Family
        app.MapDelete("/productfamilies/{id}", (Guid id) => ProductFamilyADO.Delete(dbConn, id) ? Results.NoContent() : Results.NotFound());
    }
}

public record ProductFamilyRequest(string Name);  // Com ha de llegir el POST