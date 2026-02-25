using StoreProject.Infraestructure.Persistance.Entities;

namespace StoreProject.Infraestructure.DTO;

public record ProductRequest(Guid FamilyId, string Code, string Name, decimal Discount)
{
    public Product ToProduct(Guid id)
    {
        return new Product
        {
            Id = id,
            FamilyId = FamilyId,
            Code = Code,
            Name = Name,
            Discount = Discount
        };
    }
}