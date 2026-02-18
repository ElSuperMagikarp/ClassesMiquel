namespace StoreProject.Infraestructure.DTO;

public record PurchaseRequest(Guid userId, DateOnly purchaseDate, List<ProductLineRequest> productLines);