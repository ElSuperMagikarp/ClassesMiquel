using StoreProject.Domain.Entities;

namespace StoreProject.Infraestructure.DTO;

public record PurchaseRequest(Guid userId, DateOnly purchaseDate, List<ProductLineRequest> productLines)
{
    public Purchase ToPurchase()
    {
        Purchase purchase = new Purchase
        {
            UserId = userId,
            Date = purchaseDate,
            ProductLines = new List<ProductLine>()
        };

        foreach (ProductLineRequest productLineRequest in productLines)
        {
            purchase.ProductLines.Add(productLineRequest.ToProductLine());
        }

        return purchase;
    }
}