using StoreProject.Repository;
using StoreProject.Services;
using StoreProject.Model;
using StoreProject.DTO;

namespace StoreProject.EndPoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // POST /products
        app.MapPost("/products", (ProductRequest req) =>
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                FamilyId = req.FamilyId,
                Code = req.Code,
                Name = req.Name,
                Price = req.Price,
                Discount = req.Discount
            };

            ProductADO.Insert(dbConn, product);

            return Results.Created($"/products/{product.Id}", ProductResponse.FromProduct(product));
        });

        // GET /products
        app.MapGet("/products", () =>
        {
            List<Product> products = ProductADO.GetAll(dbConn);
            List<ProductResponse> productResponses = new List<ProductResponse>();
            foreach (Product product in products)
            {
                productResponses.Add(ProductResponse.FromProduct(product));
            }
            return Results.Ok(productResponses);
        });

        // GET Product by id
        app.MapGet("/products/{id}", (Guid id) =>
        {
            Product? product = ProductADO.GetById(dbConn, id);

            return product is not null
                ? Results.Ok(ProductResponse.FromProduct(product))
                : Results.NotFound(new { message = $"Product with Id {id} not found." });
        });

        // PUT Product
        app.MapPut("/products/{id}", (Guid id, ProductRequest req) =>
        {
            Product? product = ProductADO.GetById(dbConn, id);

            if (product == null)
            {
                return Results.NotFound();
            }

            Product productUpdt = new Product
            {
                Id = id,
                FamilyId = req.FamilyId,
                Code = req.Code,
                Name = req.Name,
                Price = req.Price,
                Discount = req.Discount
            };

            ProductADO.Update(dbConn, productUpdt);

            return Results.Ok(ProductResponse.FromProduct(product));
        });

        // DELETE Product
        app.MapDelete("/products/{id}", (Guid id) => ProductADO.Delete(dbConn, id) ? Results.NoContent() : Results.NotFound());
    }
}