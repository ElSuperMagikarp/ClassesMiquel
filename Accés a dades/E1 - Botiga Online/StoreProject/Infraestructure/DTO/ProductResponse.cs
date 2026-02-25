using StoreProject.Infraestructure.Persistance.Entities;

namespace StoreProject.Infraestructure.DTO;

public record ProductResponse(Guid id, Guid familyId, string code, string name, decimal discount)
{
    public static ProductResponse FromProduct(Product product)
    {
        return new ProductResponse(product.Id, product.FamilyId, product.Code, product.Name, product.Discount);
    }
}