using StoreProject.Model;
using StoreProject.Repository;
using StoreProject.Services;

namespace StoreProject.EndPoints;

public static class ProductFamiliesEndpoints
{
    public static void MapProductFamilyEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // POST /products
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
    }
}

public record ProductFamilyRequest(string Name);  // Com ha de llegir el POST