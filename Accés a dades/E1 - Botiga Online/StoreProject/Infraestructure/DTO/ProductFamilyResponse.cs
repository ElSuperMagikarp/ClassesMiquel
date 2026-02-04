using StoreProject.Model;

namespace StoreProject.Infraestructure.DTO;

public record ProductFamilyResponse(Guid id, string name)
{
    public static ProductFamilyResponse FromProductFamily(ProductFamily productFamily)
    {
        return new ProductFamilyResponse(productFamily.Id, productFamily.Name);
    }
}