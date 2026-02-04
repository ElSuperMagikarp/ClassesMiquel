using StoreProject.Infraestructure.Persistance.Entities;

namespace StoreProject.Infraestructure.DTO;

public record ProductFamilyRequest(string Name)
{
    public ProductFamily ToProductFamily(Guid id)
    {
        return new ProductFamily
        {
            Id = id,
            Name = Name
        };
    }
}