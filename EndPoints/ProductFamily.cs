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
    }
}

public record ProductFamilyRequest(string Name);  // Com ha de llegir el POST