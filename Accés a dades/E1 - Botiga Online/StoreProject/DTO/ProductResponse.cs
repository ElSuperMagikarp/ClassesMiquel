using StoreProject.Model;

namespace StoreProject.DTO;

public record ProductResponse(Guid id, Guid familyId, string code, string name, decimal price, decimal discount)
{
    public static ProductResponse FromProduct(Product product)
    {
        return new ProductResponse(product.Id, product.FamilyId, product.Code, product.Name, product.Price, product.Discount);
    }
}