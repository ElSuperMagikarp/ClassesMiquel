using StoreProject.Repository;
using StoreProject.Services;
using StoreProject.Model;

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
                Code = req.Code,
                Name = req.Name,
                Price = req.Price
            };

            ProductADO.Insert(dbConn, product);

            return Results.Created($"/products/{product.Id}", product);
        });

        // GET /products
        app.MapGet("/products", () =>
        {
            List<Product> products = ProductADO.GetAll(dbConn);
            return Results.Ok(products);
        });

        // GET Product by id
        app.MapGet("/products/{id}", (Guid id) =>
        {
            Product? product = ProductADO.GetById(dbConn, id);

            return product is not null
                ? Results.Ok(product)
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
                Code = req.Code,
                Name = req.Name,
                Price = req.Price
            };

            ProductADO.Update(dbConn, productUpdt);

            return Results.Ok(productUpdt);
        });

        // DELETE Product
        app.MapDelete("/products/{id}", (Guid id) => ProductADO.Delete(dbConn, id) ? Results.NoContent() : Results.NotFound());
    }
}

public record ProductRequest(string Code, string Name, decimal Price);  // Com ha de llegir el POST