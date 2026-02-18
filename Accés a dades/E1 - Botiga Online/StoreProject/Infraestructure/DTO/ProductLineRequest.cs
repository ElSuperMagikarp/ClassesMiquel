using StoreProject.Domain.Entities;

namespace StoreProject.Infraestructure.DTO;

public record ProductLineRequest(Guid ProductId, int Quantity)
{
    public ProductLine ToProductLine()
    {
        return new ProductLine
        {
            ProductId = ProductId,
            Quantity = Quantity
        };
    }
}