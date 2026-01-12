using StoreProject.Model;

namespace StoreProject.DTO;

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